using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace YK.Enemy
{
    public class EnemyAvoidance : MonoBehaviour
    {
        NavMeshAgent _agent;
        public bool isAvaidance = true;
        [SerializeField] Transform _avoidPoint;
        [SerializeField] float radius;
        [SerializeField] float changeTime = 3f;
        [SerializeField] UnityEvent _onWalk, _onIdle;
        bool isOnIdle = false;
        bool isOnRun = false;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

        }
        private void OnEnable()
        {
            isAvaidance = true;
            _avoidPoint.parent = null;
            StartAvoidDance();
            _agent.isStopped = false;
        }
        private void Update()
        {
            if (isAvaidance)
            {
                if (_agent.remainingDistance > 1f)
                {
                    if (!isOnRun)
                    {
                        _onWalk?.Invoke();
                        isOnIdle = false;
                        isOnRun = true;
                    }

                }
                if (_agent.remainingDistance <= 1f)
                {
                    if (!isOnIdle)
                    {
                        _onIdle?.Invoke();
                        isOnRun = false;
                        isOnIdle = true;
                    }

                }
            }
        }
        public Vector3 GetRandomPoint()
        {
            Vector3 point = new Vector3(Random.Range(-radius, radius), transform.position.y, Random.Range(-radius, radius)) + _avoidPoint.position;
            return point;
        }
        public void AvoidDance()
        {
            if (isAvaidance && gameObject.activeInHierarchy)
            {
                Vector3 newPoint = GetRandomPoint();
                _agent.SetDestination(newPoint);
                LeanTween.delayedCall(gameObject, changeTime, () => { AvoidDance(); });
            }
        }
        public void StartAvoidDance()
        {
            isAvaidance = true;
            AvoidDance();
        }
        public void StopAvoidDance()
        {
            isAvaidance = false;
        }

    }
}