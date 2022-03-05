using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{

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


    static bool eventsSetted = false;

    private void Awake() 
    {
        if (!eventsSetted)
        {
            HealthItem.HealthUsedEvent += () => CountOfUsedHealth++;

            PlayerLogic.PlayerDiedEvent += () => CountOfGames++;
            BossFightPhase2.Boss.BossDiedEvent += () => CountOfGames++;

            PlayerLogic.PlayerGotDamage += (value) => GotDamage+=value;

            EnemyController.EnemyDiedEvent += () => CountOfKilledEnemy++;

            eventsSetted = true;
        }
    }

    private void OnDestroy() 
    {   
        // HealthItem.HealthUsedEvent -= () => CountOfUsedHealth++;

        // PlayerLogic.PlayerDiedEvent -= () => CountOfGames++;
        // BossFightPhase2.Boss.BossDiedEvent -= () => CountOfGames++;

        // PlayerLogic.PlayerGotDamage -= (value) => GotDamage+=value;

        // EnemyController.EnemyDiedEvent -= () => CountOfKilledEnemy++;
    }
}
