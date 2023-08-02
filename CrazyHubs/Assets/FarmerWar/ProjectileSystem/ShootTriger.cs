using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;

namespace YK.Projectile
{
    public class ShootTriger : MonoBehaviour
    {
        [SerializeField] ScriptableEventNoParam _onShoot;
        [SerializeField] FloatVariable _bulletCount;
        public void GetBulletCount(FloatVariable variable)
        {
            _bulletCount = variable;
        }
        public void Shoot()
        {
            if (_bulletCount.Value > 0)
            {
                _onShoot?.Raise();
            }

        }
    }
}