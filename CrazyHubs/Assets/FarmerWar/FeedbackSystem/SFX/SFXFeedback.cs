using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YK.Utils;

namespace YK.FeedbackSystem
{
    public class SFXFeedback : MonoBehaviour
    {
        [SerializeField] ScriptablePooler _pool;
        [SerializeField] AudioClip _clip;
        public void PlaySFX()
        {
            GameObject sfx = _pool.TakeFromPool();
            sfx.SetActive(true);
            sfx.GetComponent<AudioSource>().PlayOneShot(_clip);
            LeanTween.delayedCall(gameObject, _clip.length, () =>
            {
                _pool.PutBackToPool(sfx);
            });
        }
    }
}