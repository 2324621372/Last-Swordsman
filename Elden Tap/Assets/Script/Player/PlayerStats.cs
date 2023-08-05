using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

  Stats stats = new Stats();

  private int healtLevel;
  public int HealtLevel{get{return healtLevel;} set{healtLevel = value;}}
  
  private int strenghtLevel;
  public int StrenghtLevel{get{return strenghtLevel;} set {strenghtLevel = value;}}

   private void Awake()
    {
        healtLevel = stats.healtLevel;
        strenghtLevel = stats.strenghtLevel;
    }

    public void SetUpStats()
    {

    }
}
