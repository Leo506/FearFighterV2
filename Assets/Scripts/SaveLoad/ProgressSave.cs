using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Entities;

[System.Serializable]
public class ProgressSave : ISaveable
{
    Stats stats;

    public ProgressSave()
    {
        stats = ProgressSystem.GetInstance().currentStats;
    }

    public void Load()
    {
        ProgressSystem.GetInstance().SetStats(stats);
    }
}
