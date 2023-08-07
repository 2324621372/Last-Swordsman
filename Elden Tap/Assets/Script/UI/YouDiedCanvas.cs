using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDiedCanvas : MonoBehaviour
{
    [SerializeField] GameObject youDiedCanvas;
    void Start()
    {
    
    }

    void YouDiedCanvasOpener()
    {
      youDiedCanvas.SetActive(true);        
    }
}
