using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Buttons : MonoBehaviour
{

  [SerializeField] int sceneNumber;
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
    SceneManager.LoadScene(sceneNumber);
  }


}
