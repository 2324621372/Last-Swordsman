using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateFlaskButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
   int cost;

   private void OnEnable() 
   {
     cost = (PlayerManaHandler.Instance.MaxManaFlask-2)*1000;  
     costText.text = cost.ToString();
   }

   public void UpdateFlask()
   {
     if(MoneyManager.Instance.CurrentMoney>cost)
     {
     MoneyManager.Instance.CurrentMoney -= cost;
     PlayerManaHandler.Instance.IncreaseFlaskNumber();
     PlayerHealtHandler.Instance.IncreaseFlaskNumber();
     cost = (PlayerManaHandler.Instance.MaxManaFlask-2)*1000;
     costText.text = cost.ToString();
     }
   }
}
