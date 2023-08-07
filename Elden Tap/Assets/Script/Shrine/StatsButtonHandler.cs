using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsButtonHandler : MonoBehaviour
{
    UpragdeStats upragdeStats;

    void OnEnable()
    {
        upragdeStats = GetComponentInParent<UpragdeStats>();
    }

    public void ChangeStats()
    {
        upragdeStats.IncreaseLevel(gameObject);
    }

}
