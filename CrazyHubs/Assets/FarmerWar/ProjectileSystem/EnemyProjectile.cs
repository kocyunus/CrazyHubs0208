using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YK.FeedbackSystem;
using YK.Utils;

namespace YK.Projectile
{
    public class EnemyProjectile : MonoBehaviour
    {
        public ProjectileSO projectileData;
        public Transform shootPoint;
        public Transform shootEuler;
        [SerializeField] float weaponDamage = 1;
        public void Shoot()
        {
            if (gameObject.activeInHierarchy)
            {
                SpawnMuzzle(projectileData.muzzlePool);
                SpawnProjectile(projectileData.projectilePool);

            }
        }
        public void ShutgunShoot()
        {
            if (gameObject.activeInHierarchy)
            {
                SpawnMuzzle(projectileData.muzzlePool);
                SpawnProjectileShutgun(projectileData.projectilePool, 0);
                SpawnProjectileShutgun(projectileData.projectilePool, -8);
                SpawnProjectileShutgun(projectileData.projectilePool, -20);
                SpawnProjectileShutgun(projectileData.projectilePool, 20);
                SpawnProjectileShutgun(projectileData.projectilePool, 8);
            }
        }
        public void SMGShoot()
        {
            if (gameObject.activeInHierarchy)
            {
                SpawnMuzzle(projectileData.muzzlePool);
                float rand = Random.Range(-3f, 3f);
                SpawnSMGProjectile(projectileData.projectilePool, rand);

            }
        }
        public void SpawnMuzzle(ScriptablePooler pool)
        {
            GameObject muzzle = pool.TakeFromPool();
            muzzle.transform.position = shootPoint.position;
            muzzle.transform.eulerAngles = shootEuler.eulerAngles;
            muzzle.SetActive(true);
        }
        public void SpawnSMGProjectile(ScriptablePooler pool, float offset)
        {
            GameObject projectile = pool.TakeFromPool();
            projectile.transform.position = shootPoint.position;
            projectile.transform.eulerAngles = shootEuler.eulerAngles + new Vector3(0, offset, 0);
            projectile.GetComponent<ProjectileExploding>().isEnemyBullet = true;
            projectile.layer = 9;
            projectile.SetActive(true);
            projectile.layer = 9;
            projectile.TryGetComponent(out ProjectileExploding exploding);
            exploding.weaponDamage = weaponDamage;
            projectile.TryGetComponent(out IProjectileMover mover);
            mover?.Move(gameObject);
            TryGetComponent(out SFXFeedback sfx);
            sfx?.PlaySFX();
            Shaker.Instance.Shake(0.15f);


        }
        public void SpawnProjectile(ScriptablePooler pool)
        {
            GameObject projectile = pool.TakeFromPool();
            projectile.transform.position = shootPoint.position;
            projectile.transform.eulerAngles = shootEuler.eulerAngles;
            projectile.GetComponent<ProjectileExploding>().isEnemyBullet = true;
            projectile.SetActive(true);
            projectile.layer = 9;
            projectile.TryGetComponent(out ProjectileExploding exploding);
            exploding.weaponDamage = weaponDamage;
            projectile.TryGetComponent(out IProjectileMover mover);
            mover?.Move(gameObject);
            TryGetComponent(out SFXFeedback sfx);
            sfx?.PlaySFX();
            Shaker.Instance.Shake(0.15f);


        }
        public void SpawnProjectileShutgun(ScriptablePooler pool, float offset)
        {
            GameObject projectile = pool.TakeFromPool();
            projectile.transform.position = shootPoint.position;
            projectile.transform.eulerAngles = shootEuler.eulerAngles;
            projectile.transform.eulerAngles += new Vector3(0, offset, 0);
          
            projectile.SetActive(true);
            projectile.layer = 9;
            projectile.TryGetComponent(out ProjectileExplodingShutgun exploding);
            exploding.weaponDamage = weaponDamage;
            projectile.TryGetComponent(out IProjectileMover mover);
            mover?.Move(gameObject);
            TryGetComponent(out SFXFeedback sfx);
            sfx?.PlaySFX();

        }
    }
}
