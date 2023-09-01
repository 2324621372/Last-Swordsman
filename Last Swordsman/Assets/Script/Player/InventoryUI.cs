using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
   List<WeaponTypes> weapons;
   [SerializeField] TextMeshProUGUI equipText;
   // [SerializeField] private List<WeaponTypes> Weapons {get{return weapons;} set{weapons = value; ShowInventory();}}
   
   [SerializeField] RectTransform containerPrefab;
   Vector2 itemSize = new Vector2();   
   public void OnEnable()
   {
      weapons = AttackHandler.Instance.ownedWeapons;
      itemSize = containerPrefab.sizeDelta;
      ShowInventory();
   }
   public void ShowInventory()
   {
     int itemNumber = 0;
     foreach(WeaponTypes weapon in weapons)
     {
            RectTransform item = Instantiate(containerPrefab, Vector3.zero, Quaternion.identity, transform);
            item.localScale = Vector3.one;
            //item.sizeDelta = itemSize;
            SetItemInfo itemss = new SetItemInfo();
            itemss.SetText(item.gameObject, weapon);
            item.transform.Find("Equip Button").GetComponent<Button>().onClick.AddListener(() => StartCoroutine(a(equipText)));
            item.anchoredPosition = new Vector2(0,(itemSize.y)* -itemNumber);
            itemNumber++;
     }
   }

   public void AddNewWeapon(WeaponTypes newWepon)
   {
    weapons.Add(newWepon);
   }

      IEnumerator a(TextMeshProUGUI equipText)
      {
         equipText.enabled = true;
         yield return new WaitForSecondsRealtime(1f);
         equipText.enabled = false;
      }
}

public class SetItemInfo:MonoBehaviour
{
   public void SetText (GameObject contanier, WeaponTypes weaponType)
   {
        contanier.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = weaponType.weaponName;
        contanier.transform.Find("Damage").GetComponent<TextMeshProUGUI>().text = $"Damage: {weaponType.currentDamage.ToString()}";
        contanier.transform.Find("CLevel").GetComponent<TextMeshProUGUI>().text = $"Current Level: {weaponType.currentLevel.ToString()}";
        contanier.transform.Find("MLevel").GetComponent<TextMeshProUGUI>().text = $"Max Level: {weaponType.maxLevel.ToString()}";
        contanier.transform.Find("Equip Button").GetComponent<Button>().onClick.AddListener(() => AttackHandler.Instance.WeaponType = weaponType);
   }


}
