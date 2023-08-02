using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;

namespace YK.Radar
{
    public class BindDiscAnimation : MonoBehaviour
    {
        [SerializeField] FloatVariable _radarLenght;
        [SerializeField] GameObject _disc;
        private void OnEnable()
        {
            _radarLenght.OnValueChanged += ChangeDiscLenght;
            ChangeDiscLenght(_radarLenght.Value);
        }
        private void OnDisable()
        {
            _radarLenght.OnValueChanged -= ChangeDiscLenght;
        }
        public void ChangeDiscLenght(float value)
        {
            _disc.SetActive(false);
            GetComponent<Shapes.Disc>().Thickness = 0.25f;
            LeanTween.value(gameObject, 0, value, 0.75f).setEaseInQuad().setOnUpdate((val) =>
            {
                GetComponent<Shapes.Disc>().Radius = val;

            }).setOnComplete(() =>
            {

                GetComponent<Shapes.Disc>().Radius = 0;
                GetComponent<Shapes.Disc>().Thickness = 0;
                _disc.SetActive(true);
            });
        }
    }
}