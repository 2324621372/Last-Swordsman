using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSave : MonoBehaviour
{

    private void Start()
    {
      if(File.Exists((Application.persistentDataPath+"/save.txt")))
      {
        string saveFile =  File.ReadAllText(Application.persistentDataPath+"/save.txt");

        JsonSaveFile jsonSaveFile= JsonUtility.FromJson<JsonSaveFile>(saveFile);

        PlayerStats playerStats = GetComponent<PlayerStats>();

        playerStats.HealtLevel = jsonSaveFile.healtLevel;
        playerStats.ManaLevel = jsonSaveFile.manaLevel;
        playerStats.StrenghtLevel = jsonSaveFile.strenghtLevel;

        MoneyManager.Instance.CurrentMoney = jsonSaveFile.currentMoney;

        PlayerManaHandler.Instance.MaxManaFlask = jsonSaveFile.maxManaFlask;
        PlayerHealtHandler.Instance.MaxHealtFlaskNumber = jsonSaveFile.maxHealtFlaskNumber;

        AttackHandler attackHandler = GetComponent<AttackHandler>();
        attackHandler.WeaponType = jsonSaveFile.weaponTypes;
        attackHandler.WeaponType.weaponName = jsonSaveFile.weaponName;
        attackHandler.WeaponType.currentDamage = jsonSaveFile.damage;
        attackHandler.WeaponType.currentLevel = jsonSaveFile.currentLevel;




      }
    }

    private void Update()
    {
      Save();
    }

    private void OnApplicationQuit()
    {
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

      jsonSaveFile.weaponTypes = GetComponent<AttackHandler>().WeaponType;
      jsonSaveFile.weaponName = jsonSaveFile.weaponTypes.weaponName;
      jsonSaveFile.damage = jsonSaveFile.weaponTypes.currentDamage;
      jsonSaveFile.currentLevel = jsonSaveFile.weaponTypes.currentLevel;
      jsonSaveFile.maxLevel = jsonSaveFile.weaponTypes.maxLevel;


      string jsonFile = JsonUtility.ToJson(jsonSaveFile);
       File.WriteAllText(Application.persistentDataPath+"/save.txt", jsonFile);

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

}
