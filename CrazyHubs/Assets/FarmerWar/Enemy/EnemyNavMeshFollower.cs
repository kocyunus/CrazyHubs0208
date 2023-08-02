using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using YK.Controller;

namespace YK.Enemy
{
    public class EnemyNavMeshFollower : MonoBehaviour
    {
        NavMeshAgent _agent;
        bool _isRunning = false;
        [SerializeField] UnityEvent _onRun;
        GameObject _player;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        private void OnEnable()
        {
            _isRunning = false;
            _player = null;
        }
        public void FollowPlayer(GameObject player)
        {
            _player = player;
            GetComponent<EnemyAvoidance>().StopAvoidDance();
        }
        public void FollowPlayerControllObstacles(GameObject player)
        {

            _player = player;
            GetComponent<EnemyAvoidance>().StopAvoidDance();

        }
        private void Update()
        {
            if (gameObject.activeInHierarchy)
            {
                if (_player != null)
                {
                    _agent.SetDestination(_player.transform.position);
                    if (!_isRunning)
                    {
                        _onRun?.Invoke();
                        _isRunning = true;
                    }
                }
            }

        }
        public void ResetRunning() => _isRunning = false;
        public void StopFollowing(GameObject player)
        {
            if (_player == player)
            {
                _player = null;
                GetComponent<EnemyAvoidance>().StartAvoidDance();
                _isRunning = false;
            }
        }

    }
}