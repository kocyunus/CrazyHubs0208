using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;
using YK.Utils;
namespace YK.HealthSystem
{
    public class EnemyHealthSystem : MonoBehaviour, IHitable
    {
        [SerializeField] ScriptableEventFloat _onEarnExp;
        [SerializeField] ScriptablePooler _diePool;
        [SerializeField] GameObjectVariable _player;
        [SerializeField] ScriptableEventGameObject _onRemoveEnemy;
        [SerializeField] UnityEvent<float> _onHit;
        [SerializeField] UnityEvent<float> _onDie;
        [SerializeField] UnityEvent<GameObject> _onFindingPlayer;

        bool _isFinding = false;
        [SerializeField]float _health, _maxHealth = 100;
        private void OnEnable()
        {
            _health = _maxHealth;
        }
        public void Hit(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                _maxHealth += 30;
                GameObject die = _diePool.TakeFromPool();
                die.transform.position = transform.position;
                die.transform.eulerAngles = transform.eulerAngles;
                die.SetActive(true);
                _onRemoveEnemy?.Raise(gameObject);
                _onEarnExp?.Raise(20);
                _onDie?.Invoke(0);

            }
            if (_health > 0)
            {
                if (!_isFinding)
                {
                    _onFindingPlayer?.Invoke(_player.Value);
                }
                _onHit?.Invoke(_health / _maxHealth);
            }
        }
    }
}