using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyWeapon : MonoBehaviour
{
 [SerializeField] private WeaponTypes newWeapon;
 
 
 [SerializeField] private TextMeshProUGUI weaponNameTxt;
 [SerializeField] private TextMeshProUGUI weaponDamageTxt;
 [SerializeField] private TextMeshProUGUI weaponMaxLevelTxt;
 [SerializeField] private TextMeshProUGUI weaponCostTxt;


 private string weaponName;
 private string weaponDamage;
 private string weaponMaxLevel;
 private string weaponCost;
    private void OnEnable()
    {
      weaponName =  newWeapon.weaponName;
      weaponNameTxt.text = weaponName;
      
      weaponDamage = newWeapon.startDamage.ToString();
      weaponDamageTxt.text = $"Damage: {weaponDamage}";

      weaponMaxLevel = newWeapon.maxLevel.ToString();
      weaponMaxLevelTxt.text = $"Max Level: {weaponMaxLevel}";

      weaponCost = newWeapon.cost.ToString();
      weaponCostTxt.text = $"Cost {weaponCost}";

    }

public void BuyIt() 
  {
    if(MoneyManager.Instance.CurrentMoney>newWeapon.cost && FindObjectOfType<AttackHandler>().WeaponType != newWeapon)
    {
        newWeapon.currentDamage = newWeapon.startDamage;
        FindObjectOfType<AttackHandler>().WeaponType = newWeapon;
    }
    else if(FindObjectOfType<AttackHandler>().WeaponType == newWeapon)
    Debug.Log("You have this weapon");

  } 


}
