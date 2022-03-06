using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementSave : ISaveable
{
    private Achievement[] achievements;


    /// <summary>
    /// Создаёт новый экземпляр сохранений достижений
    /// </summary>
    public AchievementSave()
    {
        achievements = AchievementManager.GetAchievements();
    }

    public void Load()
    {
        AchievementManager.SetAchievements(achievements);
    }
}
