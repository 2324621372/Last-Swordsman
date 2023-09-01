using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon Type", menuName ="Create Wepon Type")]
public class WeaponTypes : ScriptableObject
{
  public string weaponName;
  public float startDamage;
  public float currentDamage;
  public int currentLevel;
  public int maxLevel;
  public int cost;
}
