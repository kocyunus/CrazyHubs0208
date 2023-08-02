using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YK.WeapnSystem;
namespace YK.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        Vector3 _spawnPoint;
        public float delay = 15f;
        public GameObject enemy;
        private void Awake()
        {
            _spawnPoint = enemy.transform.position;
        }
        public void SpawnEnemy()
        {
            LeanTween.delayedCall(gameObject, delay, () =>
            {
                if (enemy.GetComponent<EnemyWeaponManager>()._weaponLevel<=4)
                {
                    enemy.GetComponent<EnemyWeaponManager>()._weaponLevel++;
                
                }
                enemy.transform.position = _spawnPoint;
                enemy.SetActive(true);
            });
        }
    }
}