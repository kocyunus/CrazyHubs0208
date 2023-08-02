using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.WeapnSystem
{
    public class EnemyWeaponManager : MonoBehaviour
    {
       public float _weaponLevel;
        [SerializeField] List<GameObject> _weapons;
        private void OnEnable()
        {
            GetCurrentWeapon(_weaponLevel);
        }

        public void GetCurrentWeapon(float val)
        {
            for (int i = 0; i < _weapons.Count; i++)
            {
                if (i == val)
                {
                    _weapons[i].SetActive(true);
                }
                else
                {
                    _weapons[i].SetActive(false);
                }
            }
        }
    }
}