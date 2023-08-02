using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using YK.Projectile;
using YK.Radar;
using YK.Utils;

namespace YK.Controller
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] ScriptableEventGameObject _onAttackEnemy;
        
        [SerializeField] FloatVariable _movingSpeed;
        [SerializeField] Transform _stickman;
        [SerializeField] Vector2Variable _firstPoint, _secondPoint;
        public bool isMoving;
        [SerializeField] GameObject _enemy;
        [SerializeField] ScriptablePooler _controller;
        [SerializeField] Transform throwPoint;
        public bool isMyFrontEmpty = true;
        bool isChecking = false;
        private void FixedUpdate()
        {
            if (isMoving)
                Move();

            CheckMyFront();
            if (!isMoving ) 
            {
                if (_enemy!= null)
                {
                    if (isMyFrontEmpty)
                    {
                        LookEnemy(_enemy);
                        _onAttackEnemy?.Raise(_enemy);
                    }
                 
                }   
            }
         
        }
        public void StartMoving() => isMoving = true;
        public void StopMoving() => isMoving = false;
        public void Move()
        {
            transform.position += transform.TransformDirection(Vector3.forward) * _movingSpeed.Value * Time.deltaTime;
        }
        public void Rotating() 
        {
            Vector2 currentSwipe = new Vector3(_secondPoint.Value.x - _firstPoint.Value.x, _secondPoint.Value.y - _firstPoint.Value.y);
            currentSwipe.Normalize();
            

            Vector3 direction = new Vector3(currentSwipe.x, 0, currentSwipe.y);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            Quaternion newRot = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = newRot;
            _stickman.rotation = newRot;
        }
        public void GetEnemy(GameObject enemy) => _enemy = enemy;
        public void RemoveEnemy(GameObject enemy) 
        {
            if (_enemy == enemy)
            {
                _enemy = null;
            }
        }
        public void LookEnemy(GameObject enemy) 
        {
            var lookPos = enemy.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
        }

        public void GetCheckController(bool value) 
        {
            isMyFrontEmpty = value;
            isChecking = false;
        }

        public void CheckMyFront() 
        {
            if (_enemy!= null)
            {
                if (!isChecking)
                {
                    GameObject controller = _controller.TakeFromPool();

                    if (controller!= null)
                    {
                        if (controller.GetComponent<CheckMyFront>())
                        {
                            controller.GetComponent<CheckMyFront>().movement = gameObject.GetComponent<Movement>();
                        }
                     
                        controller.transform.position = throwPoint.position;
                        controller.SetActive(true);
                        controller.transform.LookAt(_enemy.transform);
                        controller.GetComponent<ProjectilePyhsicMover>().Move(gameObject);
                        isChecking = true;
                        LeanTween.delayedCall(gameObject, 0.5f, () => {
                            if (isChecking)
                            {
                                isChecking = false;
                            }
                        });
                    }
                  
                  
                }
           
            }
            if (_enemy == null)
            {
                isChecking = false;
            }
        }
    }
}