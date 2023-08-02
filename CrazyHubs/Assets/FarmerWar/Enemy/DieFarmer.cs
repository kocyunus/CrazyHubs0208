using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFarmer : MonoBehaviour
{
   
    private void OnEnable()
    {
        GetComponent<Animator>().SetTrigger("Die");
        
    }

}
