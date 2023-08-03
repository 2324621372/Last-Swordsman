using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
  public void GoToShrine()
  {
    PlayerHealtHandler.Instance.PlayerHealt = PlayerHealtHandler.Instance.PlayerMaxHealt;
    SceneManager.LoadScene("Shrine");
  }

  public void GoToPrototyoeLevel()
  {
    SceneManager.LoadScene(0);
  }

}
