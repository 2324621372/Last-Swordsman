using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon Type", menuName ="Create Wepon Type")]
public class WeaponTypes : ScriptableObject
{
  public string weaponName;
  public float damage;
  public int currentLevel;
  public const int maxLevel = 10;
}
