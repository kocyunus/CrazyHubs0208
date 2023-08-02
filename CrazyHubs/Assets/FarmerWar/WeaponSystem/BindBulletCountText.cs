using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using TMPro;

namespace YK.WeapnSystem
{
    public class BindBulletCountText : MonoBehaviour
    {
        [SerializeField] FloatVariable _bulletCount;
        private void OnEnable()
        {

        }
        private void OnDisable()
        {
            _bulletCount.OnValueChanged -= CheckText;
        }
        public void ChangeBullet(FloatVariable variable)
        {
            _bulletCount.OnValueChanged -= CheckText;
            _bulletCount = variable;
            _bulletCount.OnValueChanged += CheckText;
            CheckText(_bulletCount.Value);
        }
        private void OnDestroy()
        {
            _bulletCount.OnValueChanged -= CheckText;
        }
        private void Update()
        {
            if (_bulletCount != null && gameObject.activeInHierarchy)
            {
                CheckText(_bulletCount.Value);
            }

        }
        public void CheckText(float val)
        {
            if (_bulletCount != null && gameObject.activeInHierarchy)
            {
                GetComponent<TextMeshProUGUI>().text = _bulletCount.Value.ToString();
            }

        }
    }
}