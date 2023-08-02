using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
public class CollectableCountUI : MonoBehaviour
{
    public FloatVariable count;
    [SerializeField] GameObject panel;

    private void OnEnable()
    {
        count.OnValueChanged += CheckCount;
        CheckCount(count.Value);
    }
    private void OnDisable()
    {
        count.OnValueChanged -= CheckCount;
    }
    public void CheckCount(float val) 
    {
        if (val>0)
        {
            panel.SetActive(true);
        }
        if (val<= 0)
        {
            panel.SetActive(false);
        }
    }
}
