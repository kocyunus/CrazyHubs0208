using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YK.Controller;

namespace YK.Radar
{
    public class EnemyRadar : MonoBehaviour
    {
        public bool isFrontEmpty = true;
        [SerializeField] UnityEvent<GameObject> _onFindEnter, _onFindStay, _onFindExit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Movement>())
            {
                _onFindEnter?.Invoke(other.gameObject);

            }
        }
        private void OnTriggerStay(Collider other)
        {
            //if (other.GetComponent<Movement>())
            //{
            //    _onFindStay?.Invoke(other.gameObject);
            //}
            if (gameObject.activeInHierarchy)
            {
                if (other.GetComponent<Movement>())
                {
                    if (isFrontEmpty)
                    {
                        _onFindStay?.Invoke(other.gameObject);
                    }
                }
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Movement>())
            {
                _onFindExit?.Invoke(other.gameObject);

            }
        }

    }
}