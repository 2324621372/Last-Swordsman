using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealtBar : MonoBehaviour
{
    float enemyHealt = 100;
    float enemyMaxHealt;
    Slider enemyHealtBarSlider;
    TextMeshProUGUI enemyHealtNumber;
    StageHandler stageHandler;
    void Start()
    {   enemyHealtNumber = GetComponentInChildren<TextMeshProUGUI>();
        enemyHealtBarSlider = GetComponent<Slider>();
        stageHandler= FindObjectOfType<StageHandler>();


        SetUpBar();
        FindObjectOfType<EnemyHealtHandler>().OnEnemyDecreaseHealt += SetUpBar;
        stageHandler.newEnemyEvent += SetEventAgain;
    }

    private void SetUpBar()
    {
        enemyHealt = FindObjectOfType<EnemyHealtHandler>().EnemyHealt;
        enemyMaxHealt = FindObjectOfType<EnemyHealtHandler>().EnemyMaxHealt;
        enemyHealtBarSlider.value = enemyHealt;
        enemyHealtBarSlider.maxValue = enemyMaxHealt;
        enemyHealtNumber.text = $"{enemyHealt}/{enemyMaxHealt}";
    }

    private void SetEventAgain()
    {
         if (stageHandler != null && stageHandler.enemies.Count > 0)
    {
        foreach (var enemyGO in stageHandler.enemies)
        {
            var enemyHealthHandler = enemyGO.GetComponent<EnemyHealtHandler>();
            if (enemyHealthHandler != null)
            {
                enemyHealthHandler.OnEnemyDecreaseHealt -= SetUpBar;
                enemyHealthHandler.OnEnemyDecreaseHealt += SetUpBar;
                enemyHealt = FindObjectOfType<EnemyHealtHandler>().EnemyHealt;
                enemyMaxHealt = FindObjectOfType<EnemyHealtHandler>().EnemyMaxHealt;
                enemyHealtBarSlider.value = enemyHealt;
                enemyHealtBarSlider.maxValue = enemyMaxHealt;
                enemyHealtNumber.text = $"{enemyHealt}/{enemyMaxHealt}";
            }
        }
    }
    }

}
