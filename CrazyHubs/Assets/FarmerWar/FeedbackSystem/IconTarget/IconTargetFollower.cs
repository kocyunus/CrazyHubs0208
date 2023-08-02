using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.FeedbackSystem
{
    public class IconTargetFollower : MonoBehaviour
    {
        public GameObject target;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (gameObject.activeInHierarchy && target != null)
            {
                transform.position = new Vector3(target.transform.position.x, 0, target.transform.position.z);
            }
        }
    }
}