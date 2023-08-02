using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using UnityEngine.UI;
public class Experience : MonoBehaviour
{
    [SerializeField] FloatVariable _exp, _maxExp;
    [SerializeField] FloatVariable _level;
    float _temp;
    int id = 11;
    float _delay = 1.5f;
    [SerializeField] ScriptableEventNoParam _onLevelUp;
    [SerializeField] FloatVariable _power, _health;
    private void OnEnable()
    {
        _exp.OnValueChanged += ExpBarValue;
        _maxExp.OnValueChanged += ExpBarValue;
        _level.OnValueChanged += LevelUpBarValue;
        _temp = _exp.Value;
        ExpBarValue(1);
    }
    private void OnDisable()
    {
        _exp.OnValueChanged -= ExpBarValue;
        _maxExp.OnValueChanged -= ExpBarValue;
        _level.OnValueChanged -= LevelUpBarValue;
    }
    public void EarnExp(float earn)
    {
        _exp.Value += earn;


    }
    public void ExpBarValue(float val)
    {
        LeanTween.delayedCall(gameObject, _delay, () => {
            id = LeanTween.value(gameObject, _temp, _exp.Value, 1f).setOnUpdate((float val) => {
                GetComponent<Image>().fillAmount = val / _maxExp.Value;
                if (val >= _maxExp.Value)
                {
                    if (_exp.Value >= _maxExp.Value)
                    {
                        _level.Value++;
                        _power.Value += 2;
                        _health.Value += 20;
                        _onLevelUp?.Raise();
                    }
                    LeanTween.cancel(id);
                    _temp = 0;
                    _delay = 0.25f;
                    ExpBarValue(1);
                }
            }).setOnComplete(() => {
                _temp = _exp.Value;
                _delay = 1.5f;
            }).id;
        });
    }
    public void LevelUpBarValue(float val)
    {
        _exp.Value = _exp.Value - _maxExp.Value;
        _maxExp.Value += _level.Value * 20;

    }
}
