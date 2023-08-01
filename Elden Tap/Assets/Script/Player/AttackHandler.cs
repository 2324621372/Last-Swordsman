using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{

    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&FindObjectOfType<EnemyHealtHandler>())
        {
            AttackStage();
        }
    }

    private void AttackStage()
    {
        EnemyHealtHandler currentEnemy = FindObjectOfType<EnemyHealtHandler>();
        currentEnemy.DecreaseEnemyHealt(10f);
    }
}
