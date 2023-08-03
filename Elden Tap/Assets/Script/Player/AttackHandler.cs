using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public delegate void UpragdeWeapon();
    public UpragdeWeapon upragdeWeapon;
    [SerializeField] private WeaponTypes weaponType;
    public WeaponTypes WeaponType
    {
        get{return weaponType;}
        set
        {
            weaponType = value;
        }    
    }

    private float damage;

    void Awake() 
    {
       upragdeWeapon  += UpdateWeaponStats;
       damage = WeaponType.damage;    
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
      damage = WeaponType.damage;
    }
}
