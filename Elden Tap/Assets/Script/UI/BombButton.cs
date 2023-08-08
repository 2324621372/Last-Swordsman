using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombButton : MonoBehaviour
{
    AttackHandler attackHandler;
    TextMeshProUGUI bombText;
    void Start()
    {
       bombText = GetComponentInChildren<TextMeshProUGUI>();
       attackHandler = FindObjectOfType<AttackHandler>();
       bombText.text = attackHandler.BombNumber.ToString();
    }

   public void ThrowBombButton()
    {
      attackHandler.ThrowFire();
      bombText.text = attackHandler.BombNumber.ToString();
    }
}
