using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using YK.Utils;
using YK.Controller;
public class Collector : MonoBehaviour
{
    [SerializeField] FloatVariable _sunflower;
    [SerializeField] ScriptablePooler _sunflowerPool;

    [SerializeField] FloatVariable _pumpkin;
    [SerializeField] ScriptablePooler _pumpkinPool;

    [SerializeField] FloatVariable _carrot;
    [SerializeField] ScriptablePooler _carrotPool;
    private void OnTriggerStay(Collider other)
    {
        if (!GetComponent<Movement>().isMoving)
        {
            other.TryGetComponent(out ICollectable collectable);
                 collectable?.GetCollectings(gameObject);
  
        }
        if (!GetComponent<Movement>().isMoving)
        {
            other.TryGetComponent(out CollectablesSpend spender);
            if (_sunflower.Value>0)
            {
                spender?.SpendCollectables(_sunflower, _sunflowerPool,gameObject);
            }

            if (_pumpkin.Value>0)
            {
                spender?.SpendCollectables(_pumpkin, _pumpkinPool,gameObject);
            }

            if (_carrot.Value>0)
            {
                spender?.SpendCollectables(_carrot, _carrotPool,gameObject);
            }
         
        }
    }
}
