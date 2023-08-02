using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YK.Utils;

namespace YK.Radar
{
    public class CheckEnemyFront : MonoBehaviour
    {
        [SerializeField] ScriptablePooler _pool;
        public EnemyRadar enemyRadar;
        public EnemyRadarFollowing enemyRadarFollowing;
        public EnemyFrontCheckThrower enemyFrontCheckThrower;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform != null)
            {

                if (collision.transform.gameObject.layer == 0)
                {
                    enemyRadar.isFrontEmpty = false;
                    enemyRadarFollowing.isFrontEmpty = false;
                    enemyFrontCheckThrower.isChecking = false;
                }
                else
                {
                    enemyRadar.isFrontEmpty = true;
                    enemyRadarFollowing.isFrontEmpty = true;
                    enemyFrontCheckThrower.isChecking = false;
                }

                GetComponent<Rigidbody>().velocity = Vector3.zero;
                _pool.PutBackToPool(gameObject);

            }
        }
    }
}