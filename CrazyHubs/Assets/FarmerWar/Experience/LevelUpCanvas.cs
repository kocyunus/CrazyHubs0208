using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpCanvas : MonoBehaviour
{
    public GameObject canvas;
    public void OpenCanvas() 
    {
        canvas.SetActive(true);
        LeanTween.delayedCall(gameObject, 1, () => {
            canvas.SetActive(false);
        });

    }
}
