using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YK.Utils;

namespace YK.Projectile
{
    [CreateAssetMenu(menuName = "ProjectileSO", fileName = "ProjectileData")]
    public class ProjectileSO : ScriptableObject
    {
        public ScriptablePooler muzzlePool, projectilePool, hitPool;
    }
}