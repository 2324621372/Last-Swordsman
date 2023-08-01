using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtHandler : MonoBehaviour
{
   public static PlayerHealtHandler Instance;
   public delegate void DelegateHandler();
   public event DelegateHandler OnDecreasePlayerHealt;



    private float playerMaxHealt = 100;
    public float PlayerMaxHealt{get{return playerMaxHealt;}}
    private float playerHealt = 100;
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
        
        if(OnDecreasePlayerHealt!=null)
        {
          OnDecreasePlayerHealt();
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
    }


    public void DecreaseHealt(float takenDamage)
    {
       PlayerHealt-=takenDamage;
    }
}
