using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeaponButton : MonoBehaviour
{
    public void BuyTheweapon(WeaponTypes weaponTypes)
    {
        if(weaponTypes.cost<=MoneyManager.Instance.CurrentMoney)
        {
            MoneyManager.Instance.DecreaseMoney(weaponTypes.cost);
            AttackHandler.Instance.ownedWeapons.Add(weaponTypes);
        }
    }
}
