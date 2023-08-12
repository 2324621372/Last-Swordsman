using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
   public static MoneyManager Instance;

   public delegate void EventHandler();
   public event EventHandler setMoney;
    private float currentMoney;
    public float CurrentMoney
    {
        get{return currentMoney;}
        
        set
        {
          currentMoney = value;
          if(currentMoney>99999999)
          currentMoney = 99999999;

          if(setMoney!=null)
          setMoney();

        }
    }
    void Awake()
    {
      if(Instance==null)
      {
        Instance = this;
      }
      else if(Instance != null)
      {
        Destroy(this.gameObject);
      }
    }

   public void IncreaseMoney(float amount)
    {
        CurrentMoney += amount;
    }

   public void DecreaseMoney(float amount)
    {
       CurrentMoney -= amount;
    }
}
