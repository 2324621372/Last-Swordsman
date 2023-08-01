using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHandler : MonoBehaviour
{
   public delegate void NewEnemyEvent();
   public event NewEnemyEvent newEnemyEvent;

   EnemyHealtHandler enemyHealtHandler;
   GameObject stage;
   public List<GameObject> enemies= new List<GameObject>();
   int currentindex = 0;
   private void Awake()
    {
        currentindex = 0;
        stage = this.gameObject;
        PrepareStage();
    }

    private void PrepareStage()
    {
        foreach (Transform enemy in stage.transform)
        {
            enemies.Add(enemy.gameObject);
            enemy.gameObject.SetActive(false);
        }
        enemies[currentindex].SetActive(true);
        enemyHealtHandler =enemies[currentindex].GetComponent<EnemyHealtHandler>();
        enemyHealtHandler.OnEnemyDeath += SpawnNewEnemy;
    }

    private void SpawnNewEnemy()
    {
        enemyHealtHandler.OnEnemyDeath -= SpawnNewEnemy;
       if(currentindex<enemies.Count-1)
       {
         currentindex++;
         enemies[currentindex].SetActive(true);
         enemyHealtHandler =enemies[currentindex].GetComponent<EnemyHealtHandler>();
         enemyHealtHandler.OnEnemyDeath += SpawnNewEnemy;
         if(newEnemyEvent!=null)
         newEnemyEvent();
       }
       else
       {
          Debug.Log("Stage is done!");
       }
    }
}
