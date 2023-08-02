using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace YK.Enemy
{
    public class EnemyShootTriger : MonoBehaviour
    {
        [SerializeField] UnityEvent _onShootTriger;
        public void Shoot() => _onShootTriger?.Invoke();
    }
}