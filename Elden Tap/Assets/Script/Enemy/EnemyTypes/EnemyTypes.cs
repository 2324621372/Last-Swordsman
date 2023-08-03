using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy Type", menuName ="Create Enemy Type")]
public class EnemyTypes : ScriptableObject
{
    public string enemyName;
    public float enemyHealt;
    public float enemyMaxHealt;
    public int enemyDamage;
    public float dropMoney;
    public float hitFrequency;
}
