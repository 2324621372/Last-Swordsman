using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public delegate void DelegateHandler();

    public DelegateHandler upragdeWeapon;
    public DelegateHandler checkStats;
    public DelegateHandler upgradeStats;

    [SerializeField] private WeaponTypes weaponType;
    public WeaponTypes WeaponType
    {
        get{return weaponType;}
        set
        {
            weaponType = value;
        }    
    }

    private PlayerStats playerStats;
    private float damage;

    void Awake() 
    {
       upragdeWeapon  += UpdateWeaponStats;
       playerStats = GetComponent<PlayerStats>();
       damage = ((playerStats.StrenghtLevel-1)*5)+weaponType.damage;
       upgradeStats = () => damage = ((playerStats.StrenghtLevel-1)*5)+weaponType.damage;
    }

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
        currentEnemy.DecreaseEnemyHealt(damage);
    }

    private void UpdateWeaponStats()
    {
      damage = ((playerStats.StrenghtLevel-1)*5)+weaponType.damage;
    }
}
