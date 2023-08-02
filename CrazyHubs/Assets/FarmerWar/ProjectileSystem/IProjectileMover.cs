using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.Projectile
{
    public interface IProjectileMover
    {
        void Move(GameObject target);
    }
}