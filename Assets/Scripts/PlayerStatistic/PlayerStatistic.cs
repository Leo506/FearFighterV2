using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerStatistic : MonoBehaviour
{

    private static List<StatisticData> _statistics;
    public static List<StatisticData> Statistics
    {
        get
        {
            return _statistics;
        }
        set
        {
            if (_statistics == null)
                _statistics = value;
        }
    }

    private void Awake()
    {
        if (_statistics == null)
        {
            _statistics = StatisticFactory.GetStatistics();
        }
    }


    // TODO удалить все не нужное внизу
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

}
