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
    
}
