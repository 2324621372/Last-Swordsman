using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyTypes enemyTypes;
    private delegate void OnAttackDelegate();
    private OnAttackDelegate onAttack;
    int enemyDamage;
    float hitFrequency;

    private void Start()
    {
      enemyDamage = enemyTypes.enemyDamage;    
      hitFrequency = enemyTypes.hitFrequency;
      onAttack = ()=> {StartCoroutine(AttackThePlayer());};
      Invoke("StartTheAttack", hitFrequency);
    }
    
    private void StartTheAttack()
    {
      onAttack();
    }
    
    IEnumerator AttackThePlayer()
    {
        PlayerHealtHandler.Instance.DecreaseHealt(enemyDamage);
        yield return new WaitForSeconds(hitFrequency);
        onAttack();
    }
}
