using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YK.Utils;
using Obvious.Soap;
using YK.FeedbackSystem;
using DG.Tweening;
using Obvious.Soap;
public class CollectablesSpend : MonoBehaviour
{
    [SerializeField] ScriptableEventFloat _onUpdateMoney;
    [SerializeField] List<Transform> _points;
    bool isSpending = false;
    bool isAnimating = false;
    private void OnEnable()
    {
        isSpending = false;
    }
    public void SpendCollectables(FloatVariable variable,ScriptablePooler pool,GameObject o) 
    {
        if (!isSpending)
        {
            if (variable.Value>0)
            {
                isSpending = true;
                float value = variable.Value;
             
                LeanTween.delayedCall(gameObject, 0.025f , () => {
                    TryGetComponent(out SFXFeedback sfx);
                    sfx?.PlaySFX();
                    AnimationHome();
                    GameObject collectable = pool.TakeFromPool();
                    collectable.transform.position = o.transform.position;
                    collectable.SetActive(true);
                    int random = Random.Range(0, _points.Count);
                    Vector3 point = _points[random].position;
                    collectable.transform.DOJump(point, 5f, 1, 0.5f).OnComplete(() => {
                        _onUpdateMoney?.Raise(collectable.GetComponent<CollectingPrice>().price);
                        pool.PutBackToPool(collectable);
                        variable.Value--;
                     
                    });
                    isSpending = false;
                });
            }    
        }
    }
    public void AnimationHome() 
    {
        if (!isAnimating)
        {
            isAnimating = true;
            LeanTween.scale(gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.25f).setEasePunch().setOnComplete(() => {
                isAnimating = false;
            });
        }
      
    }
}
