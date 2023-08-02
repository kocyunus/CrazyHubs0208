using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;

namespace YK.WeapnSystem
{
    public class WeaponAnimationBind : MonoBehaviour
    {
        [SerializeField] IntVariable _currentWeapon;
        [SerializeField] List<RuntimeAnimatorController> _controller;
        private void OnEnable()
        {
            _currentWeapon.OnValueChanged += SetCurrentWeaponAnimator;
            SetCurrentWeaponAnimator(_currentWeapon.Value);
        }
        private void OnDisable()
        {
            _currentWeapon.OnValueChanged -= SetCurrentWeaponAnimator;
        }
        public void SetCurrentWeaponAnimator(int index)
        {
            for (int i = 0; i < _controller.Count; i++)
            {
                if (i == index)
                {
                    GetComponent<Animator>().runtimeAnimatorController = _controller[i];
                }
            }
        }
    }
}