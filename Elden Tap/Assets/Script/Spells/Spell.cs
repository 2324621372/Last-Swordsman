using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] ISpellTypes spellTypes;
    public ISpellTypes SpellTypes{get{return spellTypes;}}

    [SerializeField] GameObject spellVFX; //Particle System
    [SerializeField] float duration = 1f;


     private float damage;
     public float Damage{get{return damage;}}

     private float manaCost;
     public float ManaCost{get{return manaCost;}}
     
     Vector3 startPosition;
     EnemyAttack enemyAttack;
     float percantage;
     float elepsedTime;

   private void Start()
   {
     damage = spellTypes.spellDamage;
     manaCost = spellTypes.spellManaCost;
     enemyAttack = FindObjectOfType<EnemyAttack>();
     startPosition = gameObject.transform.position;
   }

   private void Update() 
   {
     if(enemyAttack == null) {Destroy(this.gameObject);}
     elepsedTime += Time.deltaTime;
     percantage = elepsedTime / duration;
     
     if(enemyAttack != null)
     transform.position = Vector3.Lerp(startPosition, enemyAttack.gameObject.transform.position, percantage);  
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
     if(other.gameObject.CompareTag("Enemy"))
     {
        other.gameObject.GetComponent<EnemyHealtHandler>().DecreaseEnemyHealt(damage);
        Instantiate(spellVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
     } 
   }
}
