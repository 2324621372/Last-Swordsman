using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flaskes : MonoBehaviour
{

  private void Start()
  {
    GetComponentInChildren<TextMeshProUGUI>().text= PlayerHealtHandler.Instance.MaxHealtFlaskNumber.ToString(); // The flask numbers same with mana and healt when the game start so it doesnt relly matter.
  }

 public void DrinkHealtFlask()
  {
    PlayerHealtHandler.Instance.DrinkFlask();
    GetComponentInChildren<TextMeshProUGUI>().text = PlayerHealtHandler.Instance.CurrentHealtFlaskNumber.ToString();
  }

  public void DrinkManaFlask()
  {
    PlayerManaHandler.Instance.DrinkManaFlask();
    GetComponentInChildren<TextMeshProUGUI>().text = PlayerManaHandler.Instance.CurrentManaFlask.ToString();
  }
}
