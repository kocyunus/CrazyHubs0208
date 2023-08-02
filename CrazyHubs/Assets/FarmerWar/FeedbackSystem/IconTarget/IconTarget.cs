using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK.FeedbackSystem
{
    public class IconTarget : MonoBehaviour
    {
        [SerializeField] GameObject _icon;
        [SerializeField] Material _detect, _attack;
        [SerializeField] Renderer _render;
        public void FindEnemy(GameObject o)
        {
            _icon.SetActive(true);
            _icon.GetComponent<IconTargetFollower>().target = o;

            _render.material = _detect;
        }
        public void RemoveEnemy(GameObject o)
        {
            _icon.GetComponent<IconTargetFollower>().target = null;
            _icon.SetActive(false);
            _render.material = _detect;
        }
        public void Attacking(GameObject o)
        {
            _render.material = _attack;
        }
    }
}