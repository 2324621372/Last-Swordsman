using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaHandler : MonoBehaviour
{
   public static PlayerManaHandler Instance;

   public delegate void OnEventHnadler();
   public event OnEventHnadler OnManaChange;

   private PlayerStats playerStats;
   [SerializeField] ParticleSystem manaVFX;

   private float playerMaxMana;
   public float PlayerMaxMana{get{return playerMaxMana;}}

   private float playerCurrentMana;
   public float PlayerCurrentMana
   {
    get{return playerCurrentMana;}
    
    set
    {
      playerCurrentMana = value;
      if(playerCurrentMana>playerMaxMana)
      {
        playerCurrentMana = playerMaxMana;
      }
      if(OnManaChange != null)
      OnManaChange();
    }
   }
   
   public int maxManaFlask = 3;

   private int currentManaFlask;
   public int CurrentManaFlask{get{return currentManaFlask;}}

   private void Awake()
   {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        playerStats = GetComponent<PlayerStats>();

        currentManaFlask = maxManaFlask;

        playerMaxMana = ((playerStats.ManaLevel-1)*10)+100;
        PlayerCurrentMana = playerMaxMana;
        playerStats.OnChangeStats += () => playerMaxMana = ((playerStats.ManaLevel-1)*10)+100;
   }

   public void DecreaseMana(float decreaseAmount)
   {
     PlayerCurrentMana-=decreaseAmount;
   }

   public void DrinkManaFlask()
   {
     if(currentManaFlask>0)
     {
      currentManaFlask--;
      PlayerCurrentMana += 40;
      manaVFX.Play();
     }
   }

    public void UpdateManaStatsInSceneChange() //This method will called in scene changes.
    {
      PlayerCurrentMana = playerMaxMana;
      currentManaFlask = maxManaFlask;
    }

    
}
