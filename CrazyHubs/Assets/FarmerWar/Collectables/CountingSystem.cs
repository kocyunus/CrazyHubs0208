using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class CountingSystem : MonoBehaviour
{
    float _count;
    public float maxCount=10;
    [SerializeField] GameObject panel;
    [SerializeField] Image _fill;
    [SerializeField] TextMeshProUGUI _text;
    public UnityEvent onDone;
    bool _isCounting = false;

    private void OnEnable()
    {
        StartCounting();
    }
    public void StartCounting() 
    {
        _isCounting = false;
        _count = maxCount;
        panel.SetActive(true);
        Counting();
    }

    public void Counting() 
    {
        if (!_isCounting &&_count>0)
        {
            _isCounting = true;
            _count--;
            _fill.fillAmount = _count / maxCount;
            _text.text = _count.ToString();
            if (_count <= 0)
            {
                panel.SetActive(false);
                onDone?.Invoke();
            }
            if (_count > 0)
            {
                LeanTween.delayedCall(gameObject, 1f, () => {
                    _isCounting = false;
                    Counting();
                });
            }
        }
    
    }
}
