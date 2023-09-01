using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ManaBar : MonoBehaviour
{
    Slider slider;
    TextMeshProUGUI manaNumber;
    void Start()
    {
        slider = GetComponent<Slider>();
        manaNumber = GetComponentInChildren<TextMeshProUGUI>();
        slider.maxValue = PlayerManaHandler.Instance.PlayerMaxMana;
        slider.value = PlayerManaHandler.Instance.PlayerCurrentMana;
        manaNumber.text = $"{PlayerManaHandler.Instance.PlayerCurrentMana}/{PlayerManaHandler.Instance.PlayerMaxMana}";
        PlayerManaHandler.Instance.OnManaChange += UpdateManaNumber;
    }

    // Update is called once per frame
    void UpdateManaNumber()
    {
        slider.maxValue = PlayerManaHandler.Instance.PlayerMaxMana;
        slider.value = PlayerManaHandler.Instance.PlayerCurrentMana;
        manaNumber.text = $"{PlayerManaHandler.Instance.PlayerCurrentMana}/{PlayerManaHandler.Instance.PlayerMaxMana}";
    }
}
