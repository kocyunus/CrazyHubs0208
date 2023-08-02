using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using YK.FeedbackSystem;
using YK.Utils;

namespace YK.Projectile
{
    public class ProjectileExploding : MonoBehaviour
    {
        [SerializeField] FloatVariable _damage,_totalDamage;
        [SerializeField] ScriptablePooler _hitPool;
        [SerializeField] ScriptableEventVector3 onPointCollid;
        public float weaponDamage;
        public bool isEnemyBullet = false;
        private void OnCollisionEnter(Collision collision)
        {
            collision.transform.TryGetComponent(out IHitable hit);

            _totalDamage.Value = _damage.Value+weaponDamage;
            if (isEnemyBullet)
            {
                _totalDamage.Value = 1 + weaponDamage;
            }
            hit?.Hit(_totalDamage.Value);

          
            if (collision.transform!= null)
            {
                if (hit!= null)
                {
                    onPointCollid?.Raise(collision.contacts[0].point);
                }
               
                GameObject impact = _hitPool.TakeFromPool();
                impact.transform.position = collision.contacts[0].point;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                TryGetComponent(out SelfPutPool selfPutPool);
                selfPutPool?.PutThePool();
                TryGetComponent(out SFXFeedback sfx);
                sfx?.PlaySFX();
            }
            
        }

    }
}