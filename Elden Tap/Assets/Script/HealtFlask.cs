using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtFlask : MonoBehaviour
{
 public void DrinkFlask()
  {
    PlayerHealtHandler.Instance.PlayerHealt += 50;
    FindObjectOfType<HealtBar>().UpdateHealtBar();
  }
}
