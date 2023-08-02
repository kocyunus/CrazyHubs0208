using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
public class SniperManager : MonoBehaviour
{
    [SerializeField] FloatVariable _sniperLevel;
    [SerializeField] List<GameObject> _snipers;
    private void OnEnable()
    {
        _sniperLevel.OnValueChanged += GetCurrentPistol;
        GetCurrentPistol(_sniperLevel.Value);
    }
    private void OnDisable()
    {
        _sniperLevel.OnValueChanged -= GetCurrentPistol;
    }
    public void GetCurrentPistol(float val)
    {
        for (int i = 0; i < _snipers.Count; i++)
        {
            if (i == _sniperLevel.Value)
            {
                _snipers[i].SetActive(true);
            }
            else
            {
                _snipers[i].SetActive(false);
            }
        }
    }
}
