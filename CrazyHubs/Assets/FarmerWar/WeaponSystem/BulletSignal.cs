using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using UnityEngine.Events;

namespace YK.WeapnSystem
{
    public class BulletSignal : MonoBehaviour
    {
        [SerializeField] FloatVariable _bullet;
        [SerializeField] UnityEvent<FloatVariable> _onChangeBullet;
        private void OnEnable()
        {
            _onChangeBullet?.Invoke(_bullet);
        }
    }
}