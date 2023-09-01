using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public static AttackHandler Instance;

    public List<WeaponTypes> ownedWeapons = new List<WeaponTypes>();

    public delegate void DelegateHandler();

    public DelegateHandler upragdeWeapon;
    public DelegateHandler checkStats;

    [SerializeField] private WeaponTypes weaponType;
    public WeaponTypes WeaponType
    {
        get{return weaponType;}
        set
        {
            weaponType = value;
            UpdateWeaponStats();
        }    
    }

    private PlayerStats playerStats;
    private float damage;

    Animator animator;
    int currentAnim =0;
    private float lastClickTime = 0f;
    private float idleTimeThreshold = 0.3f;

    void Awake() 
    {
        if(Instance == null)
        Instance = this;
        else if(Instance !=null)
        Destroy(this.gameObject);

       upragdeWeapon  += UpdateWeaponStats;
       playerStats = GetComponent<PlayerStats>();
       animator = GetComponentInChildren<Animator>();
       lastClickTime = Time.time;


   if (playerStats != null && weaponType != null)
   {
       damage = ((playerStats.StrenghtLevel - 1) * 5) + weaponType.currentDamage;
   }

 
   playerStats.OnChangeStats += () =>
   {
       if (playerStats != null && weaponType != null)
       {
           damage = ((playerStats.StrenghtLevel - 1) * 5) + weaponType.currentDamage;
       }
   };
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&FindObjectOfType<EnemyAttack>())
        {
            AttackStage();
            lastClickTime = Time.time;
            currentAnim++;
            if(currentAnim<3)
            {
                animator.SetInteger("AttackStage",currentAnim);
            }
            else
            {
                currentAnim = 1;
                animator.SetInteger("AttackStage",currentAnim);
            }
            
        }

        if (Time.time - lastClickTime > idleTimeThreshold)
        {
            currentAnim = 0;
            animator.SetInteger("AttackStage", currentAnim);
        }
    }
    private void AttackStage()
    {
        EnemyHealtHandler currentEnemy = FindObjectOfType<EnemyHealtHandler>();
        if(currentEnemy!=null)
        {
            currentEnemy.DecreaseEnemyHealt(damage);
        }
    }

    private void UpdateWeaponStats()
    {
      damage = ((playerStats.StrenghtLevel-1)*5)+weaponType.currentDamage;
    }

    public void ThrowSpell(Spell spell, float manaCost)
    {
      if(PlayerManaHandler.Instance.PlayerCurrentMana>=manaCost && FindObjectOfType<EnemyHealtHandler>() != null)
      {
       Instantiate(spell.gameObject,gameObject.transform.position, Quaternion.identity);
       PlayerManaHandler.Instance.DecreaseMana(manaCost);
      }
    }
}
