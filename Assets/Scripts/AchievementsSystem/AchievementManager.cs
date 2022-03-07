using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AchievementManager
{
    // Список достижений
    static Achievement[] achievements = new Achievement[] 
    {
        new Achievement(() => 
        {
            var tmp = PlayerStatistic.GetStatistic<GamesCount>();
            return tmp == null ? 0f : tmp.countOfGames / 3.0f; }, 0, 100),
        new Achievement(() => { return 0f; }, 1, 500)
    };


    /// <summary>
    /// Получить достижение по его id
    /// </summary>
    /// <param name="id">id искомого достижения</param>
    /// <returns>Достижение с опр id</returns>
    public static Achievement? GetAchievementById(int id)
    {
        var array = achievements.Where(a => a.id == id).ToArray();
        
        if (array.Length == 0)
            return null;
        else
            return array[0];
    }


    /// <summary>
    /// Получение всех достижений в игре
    /// </summary>
    /// <returns>Массив структур достижений</returns>
    public static Achievement[] GetAchievements()
    {
        return achievements;
    }


    /// <summary>
    /// Устанавливает новые достижения
    /// </summary>
    /// <param name="achiev">Массив достижений</param>
    public static void SetAchievements(Achievement[] achiev)
    {
        achievements = achiev;
    }
}
