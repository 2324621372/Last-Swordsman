using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtHandler : MonoBehaviour
{
 public delegate void EventHandler();
 public event EventHandler OnEnemyDecreaseHealt;
 public event EventHandler OnEnemyDeath;
 

 [SerializeField] EnemyTypes enemyType;
  private float enemyHealt;
  public float EnemyMaxHealt;
  public float EnemyHealt
  {
    get{return enemyHealt;} 
    set
    {
    enemyHealt = value; 
    if(enemyHealt<=0)
    {
     Destroy(this.gameObject);
     if(OnEnemyDeath !=null)
     {
      if(OnEnemyDecreaseHealt !=null)
      {
      OnEnemyDecreaseHealt = null;
      }
      OnEnemyDeath();
     }
    }
    else
    {
      if(OnEnemyDecreaseHealt !=null)
      OnEnemyDecreaseHealt();
    }
    }  
  }
  
 void OnEnable() 
 {
   if(enemyType==null){Debug.LogWarning("Enemy Type is null! Please look the gameObject"); return;}
   EnemyHealt = enemyType.enemyHealt; 
   EnemyMaxHealt = enemyType.enemyMaxHealt;  
 }

  public void DecreaseEnemyHealt(float reciviedDamage)
 {
   EnemyHealt -= reciviedDamage; 
   Debug.Log(EnemyHealt);
 }    

}
