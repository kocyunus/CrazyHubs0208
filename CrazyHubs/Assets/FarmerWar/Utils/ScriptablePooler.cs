using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.Utils
{
    [CreateAssetMenu(menuName = "ScriptablePooler", fileName = "ScriptablePooler")]
    public class ScriptablePooler : ScriptableObject
    {
        public GameObject _prefab;
        [SerializeField] protected int _maxSize = 10;
        [SerializeField] protected Queue<GameObject> pooledObjectQueue = new Queue<GameObject>();

        public virtual GameObject TakeFromPool()
        {
            GameObject obj;
            if (pooledObjectQueue.Count > 0)
            {
                obj = pooledObjectQueue.Dequeue();
                if (obj == null)
                {
                    obj = Instantiate(_prefab);
                }
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj = Instantiate(_prefab);
            }

            return obj;
        }

        public void PutBackToPool(GameObject t)
        {
            if (pooledObjectQueue.Count > _maxSize)
            {
                _maxSize++;
                pooledObjectQueue.Enqueue(t);
                t.gameObject.SetActive(false);
            }
            else
            {
                pooledObjectQueue.Enqueue(t);
                t.gameObject.SetActive(false);
            }
        }

    }
}