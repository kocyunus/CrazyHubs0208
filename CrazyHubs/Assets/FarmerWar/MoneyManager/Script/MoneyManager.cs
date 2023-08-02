using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Obvious.Soap;
public class MoneyManager : MonoBehaviour
{
    [SerializeField] string _moneyPrefs= "TotalMoney";
    public Vector3 startMoneyPos;
    public float moneyAmount, safeMoney;
    public TextMeshProUGUI moneyText;
    public GameObject  moneyIcon;
    bool _bounced;
    void Start()
    {
        startMoneyPos = moneyIcon.transform.position;
        if (!PlayerPrefs.HasKey(_moneyPrefs))
        {
            MoneyUpdate(150);
        }
        else
        {
            moneyAmount = PlayerPrefs.GetFloat(_moneyPrefs);
        }
        MoneyUpdate(0);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void MoneyUpdate(float miktar)
    {
        moneyAmount = PlayerPrefs.GetFloat(_moneyPrefs);
        moneyAmount = moneyAmount + miktar;

        safeMoney = safeMoney + miktar;

        if (moneyAmount < 0) moneyAmount = 0f;
        moneyText.text = ExchangeMoney(moneyAmount);
        if (!_bounced)
        {
            LeanTween.moveY(moneyIcon, moneyIcon.transform.position.y + 10f, 0.1f).setOnComplete(() => {
                LeanTween.moveY(moneyIcon, startMoneyPos.y, 0.1f);
                _bounced = false;
            });
            _bounced = true;
        }

        PlayerPrefs.SetFloat(_moneyPrefs, moneyAmount);
        PlayerPrefs.Save();
    }
    public string ExchangeMoney(float amount1)
    {
        string textAmount = "";
        if (amount1 >= 10000)
        {
            if (Mathf.Floor(amount1 / 1000) < (amount1 / 1000))
            {
                textAmount = "$" + (amount1 / 1000).ToString("N1") + "K";

                textAmount = textAmount.Replace(",", ".");
            }
            else
            {
                textAmount = "$" + (amount1 / 1000).ToString("N0") + "K";

                textAmount = textAmount.Replace(",", ".");
            }
        }
        else
        {
            textAmount = "$" + amount1.ToString("N0");
            textAmount = textAmount.Replace(",", ".");
        }
        return textAmount;
    }

}
