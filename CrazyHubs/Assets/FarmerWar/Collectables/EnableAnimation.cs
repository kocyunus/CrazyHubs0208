using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localEulerAngles = Vector3.zero;
        LeanTween.scale(gameObject, new Vector3(1.75f, 1.75f, 1.75f), 1f).setEasePunch().setOnComplete(()=> {
        });
    }

    public void JumpAnimation() 
    {
        LeanTween.scale(gameObject, new Vector3(0.5f, 0.5f, 0.5f), 0.45f).setEasePunch().setOnComplete(() => {
        });
    }
}
