using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    Achievement[] achievements;
    List<IStatisticData> statistics;

    public GameData()
    {
        achievements = AchievementManager.GetAchievements();
        statistics = PlayerStatistic.instance.statistics;
    }
}
