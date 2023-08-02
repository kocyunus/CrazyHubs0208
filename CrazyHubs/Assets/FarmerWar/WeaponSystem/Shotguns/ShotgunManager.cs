using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
public class ShotgunManager : MonoBehaviour
{
    [SerializeField] FloatVariable _shotgunLevel;
    [SerializeField] List<GameObject> _shotguns;
    private void OnEnable()
    {
        _shotgunLevel.OnValueChanged += GetCurrentPistol;
        GetCurrentPistol(_shotgunLevel.Value);
    }
    private void OnDisable()
    {
        _shotgunLevel.OnValueChanged -= GetCurrentPistol;
    }
    public void GetCurrentPistol(float val)
    {
        for (int i = 0; i < _shotguns.Count; i++)
        {
            if (i == _shotgunLevel.Value)
            {
                _shotguns[i].SetActive(true);
            }
            else
            {
                _shotguns[i].SetActive(false);
            }
        }
    }
}
