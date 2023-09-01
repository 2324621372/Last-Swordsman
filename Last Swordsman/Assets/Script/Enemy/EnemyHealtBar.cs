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
    {   
        enemyHealtNumber = GetComponentInChildren<TextMeshProUGUI>();
        enemyHealtBarSlider = GetComponent<Slider>();
        stageHandler= FindObjectOfType<StageHandler>();
  
        if(FindObjectOfType<EnemyHealtHandler>() != null)
        SetUpBar();

        else{Debug.Log("aa");}
        FindObjectOfType<EnemyHealtHandler>().OnEnemyChangeHealt += SetUpBar;
        stageHandler.newEnemyEvent += SetEventAgain;
    }

    public void SetUpBar()
    {
        EnemyHealtHandler enemyHealtHandler= FindObjectOfType<EnemyHealtHandler>();
        enemyHealt = enemyHealtHandler.EnemyHealt;
        enemyMaxHealt = enemyHealtHandler.EnemyMaxHealt;
        if(enemyHealt == null)
        Debug.Log("a");
        if(enemyHealtBarSlider == null)
        enemyHealtBarSlider.value = enemyHealt;
        enemyHealtBarSlider.maxValue = enemyMaxHealt;
        enemyHealtNumber.text = $"{enemyHealt}/{enemyMaxHealt}";
        enemyHealtBarSlider.value = enemyHealt;
    }

    private void SetEventAgain()
    {
        if (stageHandler != null && stageHandler.enemies.Count > 0)
        {
           foreach (var enemy in stageHandler.enemies)
            {
                StartCoroutine(SetNewEnemyBar(enemy));
            }
        }
    }

    IEnumerator SetNewEnemyBar (GameObject enemy)
    {
    if (enemy != null)
    {
        var enemyHealthHandler = enemy.GetComponent<EnemyHealtHandler>();
        if (enemyHealthHandler != null)
        {
            enemyHealthHandler.OnEnemyChangeHealt -= SetUpBar;
            enemyHealthHandler.OnEnemyChangeHealt += SetUpBar;
             
        }
    }

    yield return new WaitForSeconds(0.1f);
    }
}
