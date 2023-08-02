using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBarFixed : MonoBehaviour
{
    private void OnDisable()
    {
        GetComponent<Image>().fillAmount = 1f;
    }
}
