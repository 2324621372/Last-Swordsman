using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellButton : MonoBehaviour
{
    [SerializeField] Spell spell;

    AttackHandler attackHandler;
    TextMeshProUGUI bombText;
    void Start()
    {
       attackHandler = FindObjectOfType<AttackHandler>();
    }

   public void ThrowSpellButton()
    {
      attackHandler.ThrowSpell(spell,spell.SpellTypes.spellManaCost);
    }
}
