using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;

namespace YK.Radar
{
    public class FindEnemyRadar : MonoBehaviour
    {
        [SerializeField] GameObjectVariable _enemy;
        [SerializeField] List<GameObject> _enemies;
        [SerializeField] FloatVariable _radarLenght;
        [SerializeField] ScriptableEventGameObject _onFindEnemy;
        [SerializeField] ScriptableEventGameObject _onEnemyRemove;
        float _distance;
        GameObject _tempTarget;
        bool isSelected = false;
        private void OnEnable()
        {
            ChangeRadarLenght(_radarLenght.Value);
            _radarLenght.OnValueChanged += ChangeRadarLenght;
        }
        private void OnDisable()
        {
            _radarLenght.OnValueChanged -= ChangeRadarLenght;
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out IHitable hit))
            {
                AddEnemy(other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IHitable hit))
            {
                RemoveEnemy(other.gameObject);
            }
        }
        private void Update()
        {
            if (!isSelected)
            {
                SignalTarget();
            }
        }
        public void ChangeRadarLenght(float val) => GetComponent<SphereCollider>().radius = val;
        public void SignalTarget()
        {
            if (_enemies.Count > 1)
            {
                for (int i = 0; i < _enemies.Count; i++)
                {
                    if (i == 0)
                    {
                        _tempTarget = null;
                        _distance = 9999;
                    }
                    if (_distance > Vector3.Distance(_enemies[i].transform.position, transform.transform.position))
                    {
                        _distance = Vector3.Distance(_enemies[i].transform.position, transform.transform.position);
                        _tempTarget = _enemies[i];
                    }
                    if (i == _enemies.Count - 1)
                    {
                        if (_tempTarget != null)
                        {
                            _enemy.Value = _tempTarget;
                            _onFindEnemy?.Raise(_tempTarget);
                            isSelected = false;
                        }
                    }
                }
            }
            if (_enemies.Count == 1)
            {
                if (_enemies[0] != null)
                {
                    _enemy.Value = _enemies[0];
                    _onFindEnemy?.Raise(_enemy.Value);
                    isSelected = false;
                }
            }
        }
        public void AddEnemy(GameObject o)
        {
            if (!_enemies.Contains(o))
            {

                _enemies.Add(o);
            }
        }
        public void RemoveEnemy(GameObject o)
        {
            if (_enemies.Contains(o))
            {
                if (o == _enemy.Value)
                {
                    _onEnemyRemove?.Raise(o);
                    _enemy.Value = null;
                }
                _enemies.Remove(o);
            }
        }
    }
}