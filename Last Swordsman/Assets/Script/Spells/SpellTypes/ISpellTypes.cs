using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Type", menuName = "New Spell Type")]
public class ISpellTypes : ScriptableObject
{
  public string spellName;
  public int spellDamage;
  public int spellManaCost;
}
