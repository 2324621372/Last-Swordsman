using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject bombVFX; //Particle System
    [SerializeField] float duration = 1f;
    [SerializeField] float damage = 100;

     Vector3 startPosition;
     EnemyAttack enemyAttack;
     float percantage;
     float elepsedTime;
   private void Start()
   {
     enemyAttack = FindObjectOfType<EnemyAttack>();
     startPosition = gameObject.transform.position;
   }

   private void Update() 
   {
     if(enemyAttack == null) {return;}
      elepsedTime += Time.deltaTime;
     percantage = elepsedTime / duration;
     
     transform.position = Vector3.Lerp(startPosition, enemyAttack.gameObject.transform.position, percantage);  
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
     if(other.gameObject.CompareTag("Enemy"))
     {
        other.gameObject.GetComponent<EnemyHealtHandler>().DecreaseEnemyHealt(damage);
        Instantiate(bombVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
     } 
   }
}
