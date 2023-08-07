using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealtFlask : MonoBehaviour
{

 public void DrinkFlask()
  {
    PlayerHealtHandler.Instance.DecreaseFlask();
    GetComponentInChildren<TextMeshProUGUI>().text = PlayerHealtHandler.Instance.CurrentHealtFlaskNumber.ToString();
  }
}
