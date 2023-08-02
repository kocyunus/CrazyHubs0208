using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YK.Controller;
using YK.Utils;

namespace YK.Radar
{
    public class CheckMyFront : MonoBehaviour
    {
        [SerializeField] ScriptablePooler _pool;
        public Movement movement;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform != null)
            {
                if (collision.transform.gameObject.layer == 0)
                {
                    if (movement != null)
                    {
                        movement.GetCheckController(false);

                    }

                }
                else
                {
                    if (movement != null)
                    {
                        movement.GetCheckController(true);
                    }

                }

                GetComponent<Rigidbody>().velocity = Vector3.zero;
                _pool.PutBackToPool(gameObject);

            }
        }
    }
}