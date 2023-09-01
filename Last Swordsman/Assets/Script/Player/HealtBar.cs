using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealtBar : MonoBehaviour
{
   Slider playerHealtBarSlider;
   TextMeshProUGUI healtNumber;
   private void Start()
   {
     playerHealtBarSlider=GetComponent<Slider>();
     healtNumber = GetComponentInChildren<TextMeshProUGUI>();
     playerHealtBarSlider.maxValue = PlayerHealtHandler.Instance.PlayerMaxHealt;
     playerHealtBarSlider.value = PlayerHealtHandler.Instance.PlayerHealt; 
     healtNumber.text = $"{PlayerHealtHandler.Instance.PlayerHealt}/{PlayerHealtHandler.Instance.PlayerMaxHealt}";
     PlayerHealtHandler.Instance.OnChangePlayerHealt += UpdateHealtBar;
   }

   public void UpdateHealtBar()
   {
     playerHealtBarSlider.maxValue = PlayerHealtHandler.Instance.PlayerMaxHealt;
     playerHealtBarSlider.value = PlayerHealtHandler.Instance.PlayerHealt; 
     healtNumber.text = $"{PlayerHealtHandler.Instance.PlayerHealt}/{PlayerHealtHandler.Instance.PlayerMaxHealt}";
   }
}
