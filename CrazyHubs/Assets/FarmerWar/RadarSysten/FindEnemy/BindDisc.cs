using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using Shapes;

namespace YK.Radar
{
    public class BindDisc : MonoBehaviour
    {
        [SerializeField] FloatVariable _radarLenght;
        private void OnEnable()
        {
            _radarLenght.OnValueChanged += ChangeDiscLenght;
            ChangeDiscLenght(_radarLenght.Value);
        }
        private void OnDisable()
        {
            _radarLenght.OnValueChanged -= ChangeDiscLenght;
        }
        public void ChangeDiscLenght(float val)
        {
            GetComponent<Disc>().Radius = val;
        }
    }
}