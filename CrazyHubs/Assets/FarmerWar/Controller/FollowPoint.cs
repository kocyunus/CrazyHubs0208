using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.Controller
{
    public class FollowPoint : MonoBehaviour
    {
        [SerializeField] Transform point;


        // Update is called once per frame
        void FixedUpdate()
        {
            if (point != null)
            {
                transform.position = point.position;
            }
        }
    }
}