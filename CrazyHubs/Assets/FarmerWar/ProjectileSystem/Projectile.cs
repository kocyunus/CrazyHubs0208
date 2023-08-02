using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using YK.FeedbackSystem;
using YK.Utils;

namespace YK.Projectile
{
    public class Projectile : MonoBehaviour
    {
        public GameObjectVariable enemy;
        public ProjectileSO projectileData;
        public Transform shootPoint;
        public Transform shootEuler;
        [SerializeField] float weaponDamage = 1;
        [SerializeField] FloatVariable _bulletCount;
        public void Shoot() 
        {
            if (enemy.Value!= null)
            {
                if (gameObject.activeInHierarchy)
                {
                    if (_bulletCount.Value>0)
                    {
                        SpawnMuzzle(projectileData.muzzlePool);
                        SpawnProjectile(projectileData.projectilePool);
                        _bulletCount.Value--;
                    } 
                }
            }    
        }
        public void ShutgunShoot() 
        {
            if (enemy.Value != null)
            {
                if (gameObject.activeInHierarchy)
                {
                    SpawnMuzzle(projectileData.muzzlePool);
                    SpawnProjectileShutgun(projectileData.projectilePool,0);
                    SpawnProjectileShutgun(projectileData.projectilePool, -8);
                    SpawnProjectileShutgun(projectileData.projectilePool, -20);
                    SpawnProjectileShutgun(projectileData.projectilePool, 20);
                    SpawnProjectileShutgun(projectileData.projectilePool, 8);
                    Shaker.Instance.Shake(0.45f);
                    _bulletCount.Value--;
                }

            }
        }
        public void SMGShoot() 
        {
            if (enemy.Value != null)
            {
                if (gameObject.activeInHierarchy)
                {
                    if (_bulletCount.Value > 0)
                    {
                        SpawnMuzzle(projectileData.muzzlePool);
                        float rand = Random.Range(-3f, 3f);
                        SpawnSMGProjectile(projectileData.projectilePool, rand);
                        _bulletCount.Value--;
                    }

                }
            }
        }
        public void SpawnMuzzle(ScriptablePooler pool) 
        {
            GameObject muzzle = pool.TakeFromPool();
            muzzle.transform.position = shootPoint.position;
            muzzle.transform.eulerAngles = shootEuler.eulerAngles;
            muzzle.SetActive(true);
        }
        public void SpawnSMGProjectile(ScriptablePooler pool,float offset)
        {
            GameObject projectile = pool.TakeFromPool();
            projectile.transform.position = shootPoint.position;
            projectile.transform.eulerAngles = shootEuler.eulerAngles+ new Vector3(0,offset,0);
            projectile.GetComponent<ProjectileExploding>().isEnemyBullet = false;
            projectile.SetActive(true);
            projectile.layer = 6;
            projectile.TryGetComponent(out ProjectileExploding exploding);
            exploding.weaponDamage = weaponDamage;
            projectile.TryGetComponent(out IProjectileMover mover);
            mover?.Move(enemy.Value);
            TryGetComponent(out SFXFeedback sfx);
            sfx?.PlaySFX();
            Shaker.Instance.Shake(0.15f);
        }
        public void SpawnProjectile(ScriptablePooler pool) 
        {
            GameObject projectile = pool.TakeFromPool();
            projectile.transform.position = shootPoint.position;
            projectile.transform.eulerAngles = shootEuler.eulerAngles;
            projectile.GetComponent<ProjectileExploding>().isEnemyBullet = false;
            projectile.SetActive(true);
            projectile.layer = 6;
            projectile.TryGetComponent(out ProjectileExploding exploding);
            exploding.weaponDamage = weaponDamage;
            projectile.TryGetComponent(out IProjectileMover mover);
            mover?.Move(enemy.Value);
            TryGetComponent(out SFXFeedback sfx);
            sfx?.PlaySFX();
            Shaker.Instance.Shake(0.15f);
       

        }
        public void SpawnProjectileShutgun(ScriptablePooler pool,float offset)
        {
            GameObject projectile = pool.TakeFromPool();
            projectile.transform.position = shootPoint.position;
            projectile.transform.eulerAngles = shootEuler.eulerAngles;
            projectile.transform.eulerAngles += new Vector3(0, offset, 0);
            projectile.SetActive(true);
            projectile.layer = 6;
            projectile.TryGetComponent(out ProjectileExplodingShutgun exploding);
            exploding.weaponDamage = weaponDamage;
            projectile.TryGetComponent(out IProjectileMover mover);
            mover?.Move(enemy.Value);
            TryGetComponent(out SFXFeedback sfx);
            sfx?.PlaySFX();
          
        }
    }
}