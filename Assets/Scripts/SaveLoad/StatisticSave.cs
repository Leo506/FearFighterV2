using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatisticSave : ISaveable
{
    List<StatisticData> statistics;

    public StatisticSave()
    {
        statistics = PlayerStatistic.Statistics;
    }

    public void Load()
    {
        PlayerStatistic.Statistics = statistics;
        if (statistics != null)
        {
            foreach (var item in statistics)
            {
                item.Registrate();
            }
        }
    }
}
