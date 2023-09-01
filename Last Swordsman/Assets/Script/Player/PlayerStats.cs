using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

  public delegate void OnEventHandler();
  public event OnEventHandler OnChangeStats;



  private int healtLevel = 1;
  public int HealtLevel{get{return healtLevel;} 
  set
  {
    healtLevel = value;
    OnChangeStats();
  }
  }

  private int manaLevel = 1;
  public int ManaLevel{get{return manaLevel;} 
  set
  {
    manaLevel = value;
    OnChangeStats();
  }
  }
  
  private int strenghtLevel = 1;
  public int StrenghtLevel{get{return strenghtLevel;} set {strenghtLevel = value; OnChangeStats();}}


}
