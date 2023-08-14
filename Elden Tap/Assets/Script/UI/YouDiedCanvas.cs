using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDiedCanvas : MonoBehaviour
{
    [SerializeField] GameObject youDiedCanvas;
    void Start()
    {
      PlayerHealtHandler.Instance.OnPlayerDeath += YouDiedCanvasOpener;
      Debug.Log("a");
    }

    void YouDiedCanvasOpener()
    {
       Debug.Log("a");
      Time.timeScale = 0;
      youDiedCanvas.SetActive(true);
      FindObjectOfType<AttackHandler>().enabled = false;
      PlayerHealtHandler.Instance.OnPlayerDeath -= YouDiedCanvasOpener;     
    }
}
