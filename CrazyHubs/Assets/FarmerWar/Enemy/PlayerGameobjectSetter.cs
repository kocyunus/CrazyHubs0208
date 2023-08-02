using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;

namespace YK.Enemy
{
    public class PlayerGameobjectSetter : MonoBehaviour
    {
        [SerializeField] GameObjectVariable _playerVariable;
        private void OnEnable()
        {
            if (gameObject.activeInHierarchy)
            {
                _playerVariable.Value = gameObject;
            }

        }
    }
}