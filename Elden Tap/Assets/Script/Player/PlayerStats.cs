using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

  public delegate void OnEventHandler();
  public event OnEventHandler changeStats;



  private int healtLevel = 1;
  public int HealtLevel{get{return healtLevel;} 
  set
  {
    healtLevel = value;
    changeStats();
  }
  }

  private int manaLevel = 1;
  public int ManaLevel{get{return manaLevel;} 
  set
  {
    manaLevel = value;
    changeStats();
  }
  }
  
  private int strenghtLevel = 1;
  public int StrenghtLevel{get{return strenghtLevel;} set {strenghtLevel = value; changeStats();}}


}
