using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
  public void GoToShrine()
  {
    PlayerHealtHandler.Instance.UpdateHealtStats();
    SceneManager.LoadScene("Shrine");
  }

  public void GoToPrototyoeLevel()
  {
    PlayerHealtHandler.Instance.UpdateHealtStats();
    SceneManager.LoadScene(0);
  }

}
