using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpragdeStats : MonoBehaviour
{
  private delegate void OnDelegateHandler();
  private event OnDelegateHandler changeUI;

  [SerializeField] TextMeshProUGUI healtLVL;
  [SerializeField] TextMeshProUGUI strenghtLVL;
  [SerializeField] TextMeshProUGUI costText;
  
  
  private float cost = 0;
  PlayerStats playerStats;
  int currentHealtLevel;
  int currentStrengthLevel;
  

   private void OnEnable()
   {
     playerStats = FindObjectOfType<PlayerStats>();
     changeUI += ()=> {costText.text = cost.ToString();};
     
     currentHealtLevel = playerStats.HealtLevel;
     currentStrengthLevel =playerStats.StrenghtLevel;
     healtLVL.text = currentHealtLevel.ToString();
     strenghtLVL.text = currentStrengthLevel.ToString();
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
    if(MoneyManager.Instance.CurrentMoney>cost)
    {
      MoneyManager.Instance.CurrentMoney -= cost;
      playerStats.HealtLevel = int.Parse(healtLVL.text);
      playerStats.StrenghtLevel = int.Parse(strenghtLVL.text);
      Debug.Log(playerStats.StrenghtLevel);
      FindObjectOfType<AttackHandler>().upgradeStats();
      FindObjectOfType<PlayerHealtHandler>().upgradeHealtStats();
      cost = 0;
      changeUI();
    }    
   }

}
