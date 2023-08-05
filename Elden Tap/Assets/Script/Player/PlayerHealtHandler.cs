using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtHandler : MonoBehaviour
{
   public static PlayerHealtHandler Instance;
   
   public delegate void DelegateHandler();
   public event DelegateHandler OnChangePlayerHealt;
   public  DelegateHandler upgradeHealtStats;
    

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
          Debug.Log("You Died");
        }
        
        if(OnChangePlayerHealt!=null)
        {
          OnChangePlayerHealt();
        }
        }    
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
      
    upgradeHealtStats = () =>  playerMaxHealt = ((playerStats.HealtLevel-1)*10) +100; 
    }


    public void DecreaseHealt(float takenDamage)
    {
       PlayerHealt-=takenDamage;
    }
}
