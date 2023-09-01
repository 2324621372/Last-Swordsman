using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtHandler : MonoBehaviour
{
 public delegate void EventHandler();
 public event EventHandler OnEnemyChangeHealt;
 public event EventHandler OnEnemyDeath;
 

 [SerializeField] EnemyTypes enemyType;
 [SerializeField] PopUpScript damagePopUp;
  private float dropMoney;
  public float EnemyMaxHealt;
  private float time;

  private float enemyHealt;
  public float EnemyHealt
  {
    get{return enemyHealt;} 
    set
    {
    enemyHealt = value; 
    if(enemyHealt<=0)
      {
        GetComponent<EnemyAttack>().enabled = false;
        enemyHealt = 0;

        StartCoroutine(DyingPorcess());
      }
    else
    {
      if(OnEnemyChangeHealt !=null)
      OnEnemyChangeHealt();
    }
    }  
  }

    IEnumerator DyingPorcess()
    {
        
        OnEnemyChangeHealt();
        time += Time.deltaTime;
        float changingSpeed = 0;
        
        float transparency = 255f;
        while(changingSpeed<1)
        {
          changingSpeed += time*2f;
         transparency = Mathf.Lerp(transparency, 0, changingSpeed);
         GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, transparency); 
         yield return new WaitForEndOfFrame();
        }


        if (OnEnemyChangeHealt != null)
        {
          OnEnemyChangeHealt = null;
          MoneyManager.Instance.IncreaseMoney(dropMoney);
          OnEnemyDeath();
        }

        Destroy(this.gameObject);

    }

  void OnEnable() 
 {
   if(enemyType==null){Debug.LogWarning("Enemy Type is null! Please look the gameObject"); return;}
   EnemyHealt = enemyType.enemyHealt; 
   EnemyMaxHealt = enemyType.enemyMaxHealt;
   dropMoney = enemyType.dropMoney;
   FindObjectOfType<EnemyHealtBar>().SetUpBar();
 }

  public void DecreaseEnemyHealt(float reciviedDamage)
 {
   EnemyHealt -= reciviedDamage;
   if(reciviedDamage<enemyHealt || enemyHealt == null || enemyHealt == 0)
   damagePopUp.CreateText(gameObject.transform, reciviedDamage);
   else
   damagePopUp.CreateText(gameObject.transform, enemyHealt);
 }    

}
