using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpragdeWeaponSystem : MonoBehaviour
{

 [SerializeField] TextMeshProUGUI currentWeaponInfo;
 [SerializeField] TextMeshProUGUI weaponLevel;
 [SerializeField] TextMeshProUGUI weaponMaxLevel;
 [SerializeField] TextMeshProUGUI upragdeCost;

 private float cost;
  AttackHandler attackHandler;

 private void OnEnable()
    {
        currentWeaponInfo = GetComponentInChildren<TextMeshProUGUI>();
        attackHandler = FindObjectOfType<AttackHandler>();
        ShowsInfo();
    }

    private void ShowsInfo()
    {
        currentWeaponInfo.text = $"Weapon: {attackHandler.WeaponType.weaponName}";
        weaponLevel.text = $"Level: {attackHandler.WeaponType.currentLevel}";
        weaponMaxLevel.text = $"Maximum level: {attackHandler.WeaponType.maxLevel}";
        cost = Mathf.Pow(3, attackHandler.WeaponType.currentLevel - 1) * 100;
        upragdeCost.text = $"Upragde Cost: {Mathf.Pow(3, attackHandler.WeaponType.currentLevel - 1) * 100}";
    }

    public void Upragdebuton()
 {
    if(MoneyManager.Instance.CurrentMoney>cost && attackHandler.WeaponType.currentLevel<attackHandler.WeaponType.maxLevel)
    {
         MoneyManager.Instance.DecreaseMoney(cost);
         attackHandler.WeaponType.currentDamage +=10;
         attackHandler.WeaponType.currentLevel += 1;
         attackHandler.upragdeWeapon();
         ShowsInfo();
    }
 }

}
