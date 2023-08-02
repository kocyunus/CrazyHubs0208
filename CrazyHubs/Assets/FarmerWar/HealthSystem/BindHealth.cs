using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using UnityEngine.UI;

namespace YK.HealthSystem
{
    public class BindHealth : MonoBehaviour
    {
        [SerializeField] FloatVariable _healt, _maxHealth;

        private void OnEnable()
        {
            _healt.OnValueChanged += HealthBarCheck;
            _maxHealth.OnValueChanged += HealthBarCheck;
        }
        private void OnDisable()
        {
            _healt.OnValueChanged -= HealthBarCheck;
            _maxHealth.OnValueChanged -= HealthBarCheck;
        }
        public void HealthBarCheck(float val)
        {
            GetComponent<Image>().fillAmount = _healt.Value / _maxHealth.Value;
        }
    }
}