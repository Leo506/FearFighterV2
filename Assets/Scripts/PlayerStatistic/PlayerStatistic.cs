using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(GamesCount))]
[RequireComponent(typeof(GotDamage))]
[RequireComponent(typeof(UsedHealth))]
[RequireComponent(typeof(KilledEnemy))]
public class PlayerStatistic : MonoBehaviour
{
    public static PlayerStatistic instance;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(instance.gameObject);
        }

        instance = this;
    }

    // Накопительные характеристики
    #region 
    static int countOfGames = 0;        // Кол-во сыгранных игр
    static float gotDamage = 0;           // Кол-во полученного урона
    static int countOfUsedHealth = 0;   // Кол-во использованных аптечек
    static int countOfKilledEnemy = 0;  // Кол-во убитых врагов
    #endregion


    // Единоразовые
    static bool[] winBoss = new bool[5];

    // Статичные get свойства
    #region 
    public static int CountOfGames { get { return countOfGames; } private set { countOfGames = value; Debug.Log($"CountOfGames:{countOfGames}"); } }
    public static float GotDamage { get { return gotDamage; } private set { gotDamage = value; Debug.Log($"Gotdamage:{gotDamage}"); } }
    public static int CountOfUsedHealth { get { return countOfUsedHealth; } private set { countOfUsedHealth = value; Debug.Log($"countOfUsedHealth:{countOfUsedHealth}"); } }
    public static int CountOfKilledEnemy { get { return countOfKilledEnemy; } private set { countOfKilledEnemy = value; Debug.Log($"countOfKilledEnemy:{countOfKilledEnemy}"); } }
    #endregion

    public List<IStatisticData> statistics = new List<IStatisticData>();


    public void AddStatistic(IStatisticData statistic)
    {
        statistics.Add(statistic);
    }

    public void RemoveStatistic(IStatisticData statistic)
    {
        statistics.Remove(statistic);
    }
}
