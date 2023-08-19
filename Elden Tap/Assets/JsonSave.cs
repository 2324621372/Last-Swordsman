using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSave : MonoBehaviour
{

  [SerializeField] WeaponTypes starterWeapon;

    private void Start()
    {
        Load();
    }



    private void OnApplicationPause(bool pauseStatus) 
    {
      if(pauseStatus)
      {
       Save();  
      }

    }

    private void OnApplicationQuit() {
      Save();
    }

    private void Save()
    {
      JsonSaveFile jsonSaveFile = new JsonSaveFile();
      
      jsonSaveFile.playerStats =  GetComponent<PlayerStats>();
      jsonSaveFile.healtLevel = jsonSaveFile.playerStats.HealtLevel;
      jsonSaveFile.manaLevel = jsonSaveFile.playerStats.ManaLevel;
      jsonSaveFile.strenghtLevel = jsonSaveFile.playerStats.StrenghtLevel;

      jsonSaveFile.moneyManager = MoneyManager.Instance;
      jsonSaveFile.currentMoney = jsonSaveFile.moneyManager.CurrentMoney;
      
      jsonSaveFile.playerManaHandler = PlayerManaHandler.Instance;
      jsonSaveFile.maxManaFlask = jsonSaveFile.playerManaHandler.MaxManaFlask;

      jsonSaveFile.playerHealtHandler = PlayerHealtHandler.Instance;
      jsonSaveFile.maxHealtFlaskNumber = jsonSaveFile.playerHealtHandler.MaxHealtFlaskNumber;
      
      if(AttackHandler.Instance.WeaponType !=null)
      {

      jsonSaveFile.weaponTypes = AttackHandler.Instance.WeaponType;
      jsonSaveFile.weaponName = jsonSaveFile.weaponTypes.weaponName;
      jsonSaveFile.damage = jsonSaveFile.weaponTypes.currentDamage;
      jsonSaveFile.currentLevel = jsonSaveFile.weaponTypes.currentLevel;
      jsonSaveFile.maxLevel = jsonSaveFile.weaponTypes.maxLevel;
      
      foreach(WeaponTypes ownedWeapon in AttackHandler.Instance.ownedWeapons)
      {
        if(ownedWeapon !=null)
        jsonSaveFile.ownedWeapon.Add(ownedWeapon);

      }

      }
      else
      {
      jsonSaveFile.weaponTypes = starterWeapon;
      jsonSaveFile.weaponName = jsonSaveFile.weaponTypes.weaponName;
      jsonSaveFile.damage = jsonSaveFile.weaponTypes.currentDamage;
      jsonSaveFile.currentLevel = jsonSaveFile.weaponTypes.currentLevel;
      jsonSaveFile.maxLevel = jsonSaveFile.weaponTypes.maxLevel;
      jsonSaveFile.ownedWeapon.Add(jsonSaveFile.weaponTypes);
      }


       string jsonFile = JsonUtility.ToJson(jsonSaveFile);
       File.WriteAllText(Application.persistentDataPath+"/save.txt", jsonFile);

    }

    private void Load()
    {
        if (File.Exists((Application.persistentDataPath + "/save.txt")))
        {
            string saveFile = File.ReadAllText(Application.persistentDataPath + "/save.txt");

            JsonSaveFile jsonSaveFile = JsonUtility.FromJson<JsonSaveFile>(saveFile);

            PlayerStats playerStats = GetComponent<PlayerStats>();

            playerStats.HealtLevel = jsonSaveFile.healtLevel;
            playerStats.ManaLevel = jsonSaveFile.manaLevel;
            playerStats.StrenghtLevel = jsonSaveFile.strenghtLevel;

            MoneyManager.Instance.CurrentMoney = jsonSaveFile.currentMoney;

            PlayerManaHandler.Instance.MaxManaFlask = jsonSaveFile.maxManaFlask;
            PlayerHealtHandler.Instance.MaxHealtFlaskNumber = jsonSaveFile.maxHealtFlaskNumber;
            
            AttackHandler attackHandler = AttackHandler.Instance;
            if(jsonSaveFile.weaponTypes != null)
            {
              attackHandler.WeaponType = jsonSaveFile.weaponTypes;
              attackHandler.WeaponType.weaponName = jsonSaveFile.weaponName;
              attackHandler.WeaponType.currentDamage = jsonSaveFile.damage;
              attackHandler.WeaponType.currentLevel = jsonSaveFile.currentLevel;
            }

            
            if(jsonSaveFile.ownedWeapon.Count>0)
            {
            foreach(WeaponTypes ownedWeapon in jsonSaveFile.ownedWeapon)
            {
            attackHandler.ownedWeapons.Add(ownedWeapon);
            }
            }else
            {
              attackHandler.ownedWeapons.Add(starterWeapon);
            }



            if (attackHandler.WeaponType == null && jsonSaveFile.ownedWeapon == null)
            {
              attackHandler.WeaponType = starterWeapon;
              attackHandler.ownedWeapons.Add(starterWeapon);
            }

          AttackHandler.Instance.enabled = true;
        }    
    }



}



public class JsonSaveFile
{
    public PlayerStats playerStats;
    public int healtLevel;
    public int manaLevel;
    public int strenghtLevel;

    public MoneyManager moneyManager;
    public float currentMoney;

    public PlayerManaHandler playerManaHandler;
    public int maxManaFlask;

    public PlayerHealtHandler playerHealtHandler;
    public int maxHealtFlaskNumber;

    public WeaponTypes weaponTypes;
    public string weaponName;
    public float damage;
    public int currentLevel;
    public int maxLevel;

    public List<WeaponTypes> ownedWeapon = new List<WeaponTypes>();

}
