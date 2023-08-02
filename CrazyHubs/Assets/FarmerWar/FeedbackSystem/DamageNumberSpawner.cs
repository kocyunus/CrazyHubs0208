using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using DamageNumbersPro;

namespace YK.FeedbackSystem
{
    public class DamageNumberSpawner : MonoBehaviour
    {
        [SerializeField] DamageNumber _number;
        [SerializeField] FloatVariable _totalDamage;
        public void SpawnText(Vector3 point)
        {
            DamageNumber number = _number.Spawn(point + new Vector3(0, 1f, 0));
            number.number = _totalDamage.Value;

        }
    }
}