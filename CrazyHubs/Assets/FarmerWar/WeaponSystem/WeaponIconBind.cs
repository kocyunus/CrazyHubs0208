using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using UnityEngine.UI;

namespace YK.WeapnSystem
{
    public class WeaponIconBind : MonoBehaviour
    {
        [SerializeField] IntVariable _currentWeapon;
        [SerializeField] List<Sprite> _icons;
        private void OnEnable()
        {
            _currentWeapon.OnValueChanged += SetCurrentWeaponIcon;
            SetCurrentWeaponIcon(_currentWeapon.Value);
        }
        private void OnDisable()
        {
            _currentWeapon.OnValueChanged -= SetCurrentWeaponIcon;
        }
        public void SetCurrentWeaponIcon(int index)
        {
            for (int i = 0; i < _icons.Count; i++)
            {
                if (i == index)
                {
                    GetComponent<Image>().sprite = _icons[i];
                }
            }
        }
    }
}