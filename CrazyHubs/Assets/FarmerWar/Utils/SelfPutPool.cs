using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.Utils
{
    public class SelfPutPool : MonoBehaviour
    {
        public ScriptablePooler _pool;
        [SerializeField] float _delay = 0;

        private void OnEnable()
        {

            if (_delay > 0)
            {
                LeanTween.delayedCall(gameObject, _delay, () =>
                {
                    if (gameObject.activeInHierarchy)
                    {
                        PuTheSlefPool();
                    }
                });
            }
        }
        public void PutThePool()
        {
            LeanTween.cancel(gameObject);
            if (_pool != null)
            {
                _pool.PutBackToPool(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }
        public void PuTheSlefPool()
        {
            if (_pool != null)
            {
                _pool.PutBackToPool(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void OnDisable()
        {
            LeanTween.cancel(gameObject);
        }

    }
}