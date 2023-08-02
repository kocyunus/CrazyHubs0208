using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using YK.FeedbackSystem;
using YK.Utils;

namespace YK.Projectile
{
    public class ProjectileExplodingShutgun : MonoBehaviour
    {
        [SerializeField] FloatVariable _damage,_totalDamage;
        [SerializeField] ScriptablePooler _hitPool;
        [SerializeField] ScriptableEventVector3 _onCollidPoint;
        public float weaponDamage=1;
        private void OnCollisionEnter(Collision collision)
        {
          
            collision.transform.TryGetComponent(out IHitable hit);
            _totalDamage.Value = _damage.Value + weaponDamage ;
            hit?.Hit(_totalDamage.Value);
       
            if (collision.transform != null)
            {
                if (hit!= null)
                {
                    _onCollidPoint?.Raise(collision.contacts[0].point);
                }
              
                GameObject impact = _hitPool.TakeFromPool();
                impact.transform.position = collision.contacts[0].point;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                TryGetComponent(out SelfPutPoolShutgunPRojectile selfPutPool);
                selfPutPool?.PutThePool();
                TryGetComponent(out SFXFeedback sfx);
                sfx?.PlaySFX();

            }

        }
    }
}