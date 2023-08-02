using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Obvious.Soap;

namespace YK.WeapnSystem
{
    public class WeaponSelect : MonoBehaviour
    {
        [SerializeField] GameObject _before, _next;
        [SerializeField] IntVariable _haveWeaponCount;
        [SerializeField] IntVariable _currentWeapon;
        [SerializeField] List<GameObject> _weapons;
        private void OnEnable()
        {
            _currentWeapon.OnValueChanged += ActiveCurrentWeapon;
            _currentWeapon.OnValueChanged += CheckButtons;
            ActiveCurrentWeapon(_currentWeapon.Value);
            CheckButtons(_currentWeapon.Value);
        }
        private void OnDisable()
        {
            _currentWeapon.OnValueChanged -= ActiveCurrentWeapon;
            _currentWeapon.OnValueChanged -= CheckButtons;
        }
        public void ActiveCurrentWeapon(int index)
        {
            for (int i = 0; i < _weapons.Count; i++)
            {
                if (i == index)
                {
                    _weapons[i].SetActive(true);
                }
                else
                {
                    _weapons[i].SetActive(false);
                }
            }
        }
        public void NextWeapon()
        {
            if (_currentWeapon.Value + 1 <= _haveWeaponCount.Value)
            {
                _currentWeapon.Value++;
            }
        }
        public void BeforeWeapon()
        {
            if (_currentWeapon.Value - 1 >= 0)
            {
                _currentWeapon.Value--;
            }
        }
        public void CheckButtons(int index)
        {
            _before.SetActive(true);
            _next.SetActive(true);
            if (index == 0)
            {
                _before.SetActive(false);
            }
            if (index == _haveWeaponCount.Value)
            {
                _next.SetActive(false);
            }
        }
    }
}