using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.Utils
{
    public class LookCamera : MonoBehaviour
    {

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}