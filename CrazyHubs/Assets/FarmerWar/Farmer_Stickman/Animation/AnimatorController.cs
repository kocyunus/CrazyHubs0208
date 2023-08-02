using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
namespace YK.Controller
{
    public class AnimatorController : MonoBehaviour
    {
        Animator _animator;
        bool _isAttacking = false;
        [SerializeField] FloatVariable _bullet;
        public void GetBulletCount(FloatVariable variable)
        {
            _bullet = variable;
        }
        private void Awake()
        {
            _isAttacking = false;
            _animator = GetComponent<Animator>();
        }

        public void AttacToEnemy(GameObject enemy) 
        {
            if (_bullet.Value>0)
            {
                if (!_isAttacking)
                {
                    _animator.SetTrigger("Action");
                    _isAttacking = true;
                }
            }
         
        }
        public void ResetAttacking() => _isAttacking = false;
      
    }
}