using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.Utils
{
    public class SelfPutPoolShutgunPRojectile : MonoBehaviour
    {
        public ScriptablePooler _pool;
        [SerializeField] ScriptablePooler _hitPool;
        [SerializeField] float _delay = 0;

        private void OnEnable()
        {

            if (_delay > 0)
            {
                LeanTween.delayedCall(gameObject, _delay, () =>
                {
                    if (gameObject.activeInHierarchy)
                    {
                        PutThePool();
                    }
                });
            }
        }
        public void PutThePool()
        {

            if (_pool != null)
            {
                _pool.PutBackToPool(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            GameObject impact = _hitPool.TakeFromPool();
            impact.transform.position = transform.position;
            impact.SetActive(true);

        }
        private void OnDisable()
        {
            LeanTween.cancel(gameObject);
        }
    }
}