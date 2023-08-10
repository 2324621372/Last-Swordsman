using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
  public void GoToShrine()
  {
    PlayerHealtHandler.Instance.UpdateHealtStatsInSceneChange();
    PlayerManaHandler.Instance.UpdateManaStatsInSceneChange();
    SceneManager.LoadScene("Shrine");
  }

  public void GoToPrototyoeLevel()
  {
    PlayerHealtHandler.Instance.UpdateHealtStatsInSceneChange();
    PlayerManaHandler.Instance.UpdateManaStatsInSceneChange();
    SceneManager.LoadScene(1);
  }

}
