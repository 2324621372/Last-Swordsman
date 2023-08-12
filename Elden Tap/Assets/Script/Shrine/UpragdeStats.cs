using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpragdeStats : MonoBehaviour
{
  private delegate void OnDelegateHandler();
  private event OnDelegateHandler changeUI;

  [SerializeField] TextMeshProUGUI healtLVL;
  [SerializeField] TextMeshProUGUI manaLVL;
  [SerializeField] TextMeshProUGUI strenghtLVL;
  [SerializeField] TextMeshProUGUI costText;
  
  
  private float cost = 0;
  PlayerStats playerStats;

  

   private void OnEnable()
   {
     playerStats = FindObjectOfType<PlayerStats>();
     changeUI += ()=> {costText.text =  $"Cost: {cost}";};

     healtLVL.text = playerStats.HealtLevel.ToString();
     strenghtLVL.text = playerStats.StrenghtLevel.ToString();
     manaLVL.text = playerStats .ManaLevel.ToString();
     costText.text = $"Cost: {cost}";
     changeUI();
   }

   private void OnDisable() {
    cost = 0;
   }

   public void IncreaseLevel(GameObject button)//This method is adding to buttons
   {

     int newLevel = int.Parse(button.GetComponentInParent<TextMeshProUGUI>().text) +1;
     button.GetComponentInParent<TextMeshProUGUI>().text = newLevel.ToString();
     cost += Mathf.Round(Mathf.Pow(3, newLevel-1)*5);
     changeUI();
   }

   public void BuyIt()
   {
    if(MoneyManager.Instance.CurrentMoney>=cost)
    {
      MoneyManager.Instance.CurrentMoney -= cost;
      playerStats.HealtLevel = int.Parse(healtLVL.text);
      playerStats.StrenghtLevel = int.Parse(strenghtLVL.text);
      playerStats.ManaLevel = int.Parse(manaLVL.text);
      cost = 0;
      changeUI();
    }    
   }

}
