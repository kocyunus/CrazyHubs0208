using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obvious.Soap;
using UnityEngine.UI;
public class UpgradeThisWeapon : MonoBehaviour
{
    public int weapounIndex;
    public IntVariable currentWeapon;
    public FloatVariable weaponVariable;
    public ScriptableEventFloat onUpdateMoney;
    public GameObject panel;
    public FloatVariable cost;

    private void Update()
    {
        if (weapounIndex== currentWeapon.Value)
        {
            float money = PlayerPrefs.GetFloat("TotalMoney");
            if (money>= cost.Value)
            {
                GetComponent<Image>().enabled = true;
                panel.SetActive(true);
            }
            else
            {
                GetComponent<Image>().enabled = false;
                panel.SetActive(false);
            }
        }
        else
        {
            GetComponent<Image>().enabled = false;
            panel.SetActive(false);
        }
    }
    public void UpgradeThis() 
    {
        float money = PlayerPrefs.GetFloat("TotalMoney");
        if (money >= cost.Value) 
        {
            onUpdateMoney?.Raise(-cost.Value);
            weaponVariable.Value++;
            cost.Value += weaponVariable.Value * 150;
        }
    }
}
