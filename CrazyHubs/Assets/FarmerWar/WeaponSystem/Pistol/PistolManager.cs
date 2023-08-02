using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
public class PistolManager : MonoBehaviour
{
    [SerializeField] FloatVariable _pistolLevel;
    [SerializeField] List<GameObject> _pistols;
    private void OnEnable()
    {
        _pistolLevel.OnValueChanged += GetCurrentPistol;
        GetCurrentPistol(_pistolLevel.Value);
    }
    private void OnDisable()
    {
        _pistolLevel.OnValueChanged -= GetCurrentPistol;
    }
    public void GetCurrentPistol(float val) 
    {
        for (int i = 0; i < _pistols.Count; i++)
        {
            if (i == _pistolLevel.Value)
            {
                _pistols[i].SetActive(true);
            }
            else
            {
                _pistols[i].SetActive(false);
            }
        }
    }

}
