using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsUI : MonoBehaviour
{
    [SerializeField] AchievementItem[] items;  // UI items достижений

    public void UpdateUI()
    {
        foreach (var item in items)
        {
            Achievement? tmp = AchievementManager.GetAchievementById(item.id);
            if (tmp.HasValue)
            {
                Achievement achievement = tmp.Value;
                item.UpdateView(achievement.currentProgress, achievement.IsGot);
            }
        }
    }
}
