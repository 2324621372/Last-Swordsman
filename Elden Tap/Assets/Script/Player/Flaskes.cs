using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flaskes : MonoBehaviour
{

 public void DrinkHealtFlask()
  {
    PlayerHealtHandler.Instance.DrinkFlask();
    GetComponentInChildren<TextMeshProUGUI>().text = PlayerHealtHandler.Instance.CurrentHealtFlaskNumber.ToString();
  }

  public void DrinkManaFlask()
  {
    PlayerManaHandler.Instance.DrinkManaFlask();
    Debug.Log( PlayerManaHandler.Instance.CurrentManaFlask);
    GetComponentInChildren<TextMeshProUGUI>().text = PlayerManaHandler.Instance.CurrentManaFlask.ToString();
  }
}
