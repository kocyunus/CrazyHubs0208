using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.Enemy
{
    public class EnemyAnimatorController : MonoBehaviour
    {
        Animator _animator;
        bool _isAttacking = false;
        private void Awake()
        {
            _isAttacking = false;
            _animator = GetComponent<Animator>();
        }
        public void AttacToEnemy(GameObject enemy)
        {
            if (!_isAttacking)
            {
                _animator.SetTrigger("Action");
                _isAttacking = true;
            }
        }
        public void ResetAttacking() => _isAttacking = false;
    }
}