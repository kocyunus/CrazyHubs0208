using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YK.Utils;
using Obvious.Soap;
using DG.Tweening;
using UnityEngine.Events;
using YK.FeedbackSystem;
public class StackArea : MonoBehaviour,ICollectable
{
    public UnityEvent onCollectingDone;
    [SerializeField] FloatVariable _stackCount;
    [SerializeField] List<GameObject> _collectables;
    [SerializeField] List<Transform> _points;
    [SerializeField] Sprite _sprite;
    [SerializeField] ScriptablePooler _pool;
    public bool isCollectable = false;
    bool isStacking = false;
    public void GetCollectings(GameObject o)
    {
        if (isCollectable)
        {
            isCollectable = false;
            for (int i = 0; i < _collectables.Count; i++)
            {
                int count = i;
                LeanTween.delayedCall(gameObject, 0.05f * count, () => {
                    TryGetComponent(out SFXFeedback sfx);
                    sfx?.PlaySFX();
                    GameObject collectable = _collectables[count];
                    collectable.transform.DOJump(o.transform.position, 2.5f, 1, 0.5f).OnComplete(() => {
                        _pool.PutBackToPool(collectable);
                        _stackCount.Value++;
                     
                        if (_collectables.Count-1 == count)
                        {
                            _collectables.Clear();
                            onCollectingDone?.Invoke();
                        }
                    });
                });

            }
        }
    }

    private void OnEnable()
    {
    }

    public void SpawnCollectables() 
    {
        for (int i = 0; i < _points.Count; i++)
        {
            int count = i;
            LeanTween.delayedCall(gameObject, count * 0.05f, () => {
                GameObject collectable = _pool.TakeFromPool();
                if (collectable!= null)
                {
                    collectable.transform.position = _points[count].position;
                    collectable.SetActive(true);
                    _collectables.Add(collectable);
                 
                }
                if (count == _points.Count - 1)
                {
                    isCollectable = true;
                }
            });
           
        }
    }
}
