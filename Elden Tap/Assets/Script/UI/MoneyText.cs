using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyText : MonoBehaviour
{
    TextMeshProUGUI moneyTxt;
    void Start()
    {
        moneyTxt = GetComponent<TextMeshProUGUI>();
        moneyTxt.text = MoneyManager.Instance.CurrentMoney.ToString();
        MoneyManager.Instance.setMoney += UpdateText;
    }

    void UpdateText()
    {
        moneyTxt.text = MoneyManager.Instance.CurrentMoney.ToString();
        Debug.Log(MoneyManager.Instance.CurrentMoney.ToString());
    }

}
