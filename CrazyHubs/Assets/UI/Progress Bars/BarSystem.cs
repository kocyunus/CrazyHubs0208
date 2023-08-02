using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarSystem : MonoBehaviour
{
    [SerializeField] Image _fill;
    [SerializeField] Sprite _green, _yellow, _red;
    public void Progress(float val) 
    {
        if (val>0.6f)
        {
            _fill.sprite = _green;
        }
        if (val<=0.6f && val>0.3f)
        {
            _fill.sprite = _yellow;
        }
        if (val<=0.3f)
        {
            _fill.sprite = _red;
        }
        _fill.fillAmount = val;
    }
}
