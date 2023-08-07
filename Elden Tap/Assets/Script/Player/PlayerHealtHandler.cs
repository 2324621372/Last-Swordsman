using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtHandler : MonoBehaviour
{
   public static PlayerHealtHandler Instance;
   
   public delegate void EventHandler();
   public event EventHandler OnChangePlayerHealt;
   public event EventHandler OnPlayerDeath;
   public EventHandler upgradeHealtStats; // Yeah, I know name is EventHandler but this is not a event :)
    

    PlayerStats playerStats;

    private float playerMaxHealt;
    public float PlayerMaxHealt{get{return playerMaxHealt;}}
    private float playerHealt;
    public float PlayerHealt
    {
      get{return playerHealt;}
      set
      {
        playerHealt = value;
       if(playerHealt>=playerMaxHealt)
        {
        playerHealt = playerMaxHealt;
        }
       else if(playerHealt<=0)
        {
          if(OnPlayerDeath != null)
          {
            OnPlayerDeath();
          }
        }
        
        if(OnChangePlayerHealt!=null)
        {
          OnChangePlayerHealt();
        }
        }    
    }

    private int maxHealtFlaskNumber = 3;
    // public int MaxHealtFlaskNumber
    // {
    //   get{return maxHealtFlaskNumber;}
    // }


    private int currentHealtFlaskNumber;
    public int CurrentHealtFlaskNumber
    {
      get{return currentHealtFlaskNumber;}
      
    }
    

    private void Awake() 
    {
      DontDestroyOnLoad(this.gameObject);
      if(Instance == null)
      {
        Instance = this;
      }
      else if(Instance!=null)
      {
        Destroy(this.gameObject);
      }
     
      playerStats = GetComponent<PlayerStats>();  
      playerMaxHealt = ((playerStats.HealtLevel-1)*10) +100;
      playerHealt = playerMaxHealt;
      currentHealtFlaskNumber = maxHealtFlaskNumber;
      
    upgradeHealtStats = () =>  playerMaxHealt = ((playerStats.HealtLevel-1)*10) +100; 
    }


    public void DecreaseHealt(float takenDamage)
    {
       PlayerHealt-=takenDamage;
    }

    public void DecreaseFlask()
    {
      if(currentHealtFlaskNumber>0)
      {
        currentHealtFlaskNumber--;
        PlayerHealt += 50;
        GetComponentInChildren<ParticleSystem>().Play();
      }
    }

    public void UpdateHealtStats() //This method will called in scene changes.
    {
      PlayerHealt = PlayerMaxHealt;
      currentHealtFlaskNumber = maxHealtFlaskNumber;
    }
}
