using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
public class RifleManager : MonoBehaviour
{
    [SerializeField] FloatVariable _rifleLEvel;
    [SerializeField] List<GameObject> _rifles;
    private void OnEnable()
    {
        _rifleLEvel.OnValueChanged += GetCurrentPistol;
        GetCurrentPistol(_rifleLEvel.Value);
    }
    private void OnDisable()
    {
        _rifleLEvel.OnValueChanged -= GetCurrentPistol;
    }
    public void GetCurrentPistol(float val)
    {
        for (int i = 0; i < _rifles.Count; i++)
        {
            if (i == _rifleLEvel.Value)
            {
                _rifles[i].SetActive(true);
            }
            else
            {
                _rifles[i].SetActive(false);
            }
        }
    }
}
