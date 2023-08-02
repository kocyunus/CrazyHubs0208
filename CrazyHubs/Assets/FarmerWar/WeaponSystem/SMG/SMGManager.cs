using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
public class SMGManager : MonoBehaviour
{
    [SerializeField] FloatVariable _smgLevel;
    [SerializeField] List<GameObject> _smgs;
    private void OnEnable()
    {
        _smgLevel.OnValueChanged += GetCurrentPistol;
        GetCurrentPistol(_smgLevel.Value);
    }
    private void OnDisable()
    {
        _smgLevel.OnValueChanged -= GetCurrentPistol;
    }
    public void GetCurrentPistol(float val)
    {
        for (int i = 0; i < _smgs.Count; i++)
        {
            if (i == _smgLevel.Value)
            {
                _smgs[i].SetActive(true);
            }
            else
            {
                _smgs[i].SetActive(false);
            }
        }
    }
}
