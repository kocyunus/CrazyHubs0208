using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YK.Controller;
using YK.Projectile;
using YK.Radar;
using YK.Utils;

public class EnemyFrontCheckThrower : MonoBehaviour
{
    [SerializeField]ScriptablePooler _controller;
    public bool isChecking = false;
    [SerializeField] Transform throwPoint;
    public EnemyRadar enemyRadar;
    public EnemyRadarFollowing enemyRadarFollowing;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            if (other != null)
            {
                if (!isChecking)
                {
                    GameObject controller = _controller.TakeFromPool();
                    controller.transform.position = throwPoint.position;
                    controller.SetActive(true);
                    controller.transform.LookAt(other.transform);
                    controller.GetComponent<CheckEnemyFront>().enemyRadar = enemyRadar;
                    controller.GetComponent<CheckEnemyFront>().enemyRadarFollowing = enemyRadarFollowing;
                    controller.GetComponent<CheckEnemyFront>().enemyFrontCheckThrower = this;
                    controller.GetComponent<ProjectilePyhsicMover>().Move(gameObject);
                    isChecking = true;
                    LeanTween.delayedCall(gameObject, 0.5f, () => {
                        if (isChecking)
                        {
                            isChecking = false;
                        }
                    });
                }

            }
        }
        else
        {
            isChecking = false;
        }
    }

}
