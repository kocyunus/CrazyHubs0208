using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace YK.Enemy
{
    public class EnemyAttacker : MonoBehaviour
    {
        NavMeshAgent _agent;
        [SerializeField] UnityEvent<GameObject> _onAttacking;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        private void OnEnable()
        {
            
        }
        public void Attacking(GameObject player)
        {
            if (gameObject.activeInHierarchy)
            {
                transform.LookAt(player.transform);
                _agent.isStopped = true;
                _onAttacking?.Invoke(player);
            }

        }
        public void StopAttacking(GameObject player)
        {
            if (gameObject.activeInHierarchy)
            {
                _agent.isStopped = false;
            }

        }
    }
}