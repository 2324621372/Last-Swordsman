using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyWeapon : MonoBehaviour
{
  [SerializeField] RectTransform shopContainer;
  Vector2 shopSize;
  [SerializeField] List<WeaponTypes> availableWeapon;

  List<RectTransform> currentContainer = new List<RectTransform>();

  int itemNumber = 1;

  private void Start()
  {
    shopSize = shopContainer.sizeDelta;
    SetLists();

    
  }

  public void SetLists()
  {
    if(currentContainer.Count>0)
    {
      foreach(RectTransform current in currentContainer)
      {
        Destroy(current.gameObject);
      }

      itemNumber = 1;
    }

         foreach (WeaponTypes alreadyBoughtWeapon in AttackHandler.Instance.ownedWeapons)
         {
              if (availableWeapon.Contains(alreadyBoughtWeapon))
              {
                  availableWeapon.Remove(alreadyBoughtWeapon);
              }
        }

     foreach(WeaponTypes avaliableWeapon in availableWeapon)
    {
      itemNumber++;
      RectTransform shopWeapon = Instantiate(shopContainer, Vector3.zero, Quaternion.identity, transform);
      SetShopItemInfo setShopItemInfo = new SetShopItemInfo();
      setShopItemInfo.SetInfo(shopWeapon.gameObject,  avaliableWeapon, this);
      shopWeapon.anchoredPosition = new Vector2(0,100+(shopWeapon.transform.position.y+(-itemNumber*shopSize.y)));
      currentContainer.Add(shopWeapon);
    }
  }

  public void SetListsAgain()
  {

  }

  // private void OnDisable()
  // {
  //  foreach(RectTransform x in transform)
  //  {
  //   x.gameObject.SetActive(false);
  //   itemNumber = 1;
  //  } 
  //    }
}

public class SetShopItemInfo
{
  public void SetInfo(GameObject shopContainer, WeaponTypes weaponTypes, BuyWeapon buyWeapon)
  {
    shopContainer.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = $"{weaponTypes.weaponName}";
    shopContainer.transform.Find("Damage").GetComponent<TextMeshProUGUI>().text = $"Damage: {weaponTypes.currentDamage}";
    shopContainer.transform.Find("Level").GetComponent<TextMeshProUGUI>().text = $"Max Level: {weaponTypes.maxLevel}";
    shopContainer.transform.Find("Buy Button").GetComponent<Button>().onClick.AddListener( () =>shopContainer.transform.Find("Buy Button").GetComponent<BuyWeaponButton>().BuyTheweapon(weaponTypes));
    shopContainer.transform.Find("Buy Button").GetComponent<Button>().onClick.AddListener ( ()=>buyWeapon.SetLists());  
  }
}
