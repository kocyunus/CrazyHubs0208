using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using UnityEngine.UI;
using TMPro;

namespace YK.WeapnSystem
{
    public class AmmoController : MonoBehaviour
    {
        [SerializeField] FloatVariable _bulletCount;
        [SerializeField] FloatVariable _maxBulletCount;
        [SerializeField] GameObject _weapon;
        [SerializeField] GameObject _panel, weaponPanel;
        [SerializeField] Image _fill;
        [SerializeField] TextMeshProUGUI _text;
        float _count;
        [SerializeField] float _maxCount = 10f;
        bool isCounting = false;
        private void OnEnable()
        {
            _bulletCount.OnValueChanged += CheckBullets;
            _count = _maxCount;
            _bulletCount.Value = _maxBulletCount.Value;
        }
        private void OnDisable()
        {
            _bulletCount.OnValueChanged -= CheckBullets;
        }
        private void Update()
        {
            CheckBullets(_bulletCount.Value);
        }
        public void CheckBullets(float val)
        {
            if (_weapon.activeInHierarchy)
            {
                if (val <= 0)
                {
                    _panel.SetActive(true);
                    weaponPanel.SetActive(false);
                    if (!isCounting)
                    {
                        Counting();
                        isCounting = true;
                    }
                }
                if (val > 0)
                {
                    _panel.SetActive(false);

                }
            }
            else
            {
                _panel.SetActive(false);
            }
        }
        public void ChangeBullet(FloatVariable variable) => _bulletCount = variable;
        public void ChangeWeapon(GameObject weapon) => _weapon = weapon;
        public void Counting()
        {
            _count--;
            if (_panel.activeInHierarchy)
            {
                _text.text = _count.ToString();
                _fill.fillAmount = _count / _maxCount;
            }

            if (_count > 0)
            {
                LeanTween.delayedCall(gameObject, 1f, () =>
                {
                    Counting();
                });
            }
            if (_count <= 0)
            {
                _bulletCount.Value = _maxBulletCount.Value;
                _count = _maxCount;
                if (_weapon.activeInHierarchy)
                {
                    weaponPanel.SetActive(true);
                }

                isCounting = false;
            }



        }

    }
}