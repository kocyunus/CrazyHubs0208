using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using YK.Utils;
namespace YK.HealthSystem
{
    public class HealthSystem : MonoBehaviour, IHitable
    {
        [SerializeField] FloatVariable _health, _maxHealth;
        [SerializeField] ScriptableEventNoParam _onHit, _onDie;
        [SerializeField] ScriptablePooler pool;
        private void OnEnable()
        {
            _health.Value = _maxHealth.Value;
        }
        public void Hit(float damage)
        {
            _health.Value -= damage;
            if (_health.Value <= 0)
            {
                GameObject figure = pool.TakeFromPool();
                figure.transform.position = transform.position;
                figure.transform.eulerAngles = transform.eulerAngles;
                figure.SetActive(true);
                _onDie?.Raise();
            }
            if (_health.Value > 0)
            {
                _onHit?.Raise();
            }
        }
    }
}