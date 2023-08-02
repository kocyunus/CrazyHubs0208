using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.Projectile
{
    public class ProjectilePyhsicMover : MonoBehaviour, IProjectileMover
    {
        [SerializeField] float moveSpeed = 15;

        private void OnEnable()
        {
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        private void OnDisable()
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        public void Move(GameObject target)
        {
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * moveSpeed;
            }
            else
            {
                gameObject.AddComponent<Rigidbody>();
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * moveSpeed;
            }
        }
    }
}