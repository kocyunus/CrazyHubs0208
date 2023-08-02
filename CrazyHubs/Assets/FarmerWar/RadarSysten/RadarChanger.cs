using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;

namespace YK.Radar
{
    public class RadarChanger : MonoBehaviour
    {
        [SerializeField] FloatVariable _radarLenght;
        [SerializeField] float _lenght;
        private void OnEnable()
        {
            _radarLenght.Value = _lenght;
        }
    }
}