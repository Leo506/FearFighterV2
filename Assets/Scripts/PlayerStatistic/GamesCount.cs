using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamesCount : StatisticData
{
    public int countOfGames { get; private set; }  // Кол-во сыгранных игр

    // Реализация синглтона
    #region
    private static GamesCount instance;

    private GamesCount()
    {
        countOfGames = 0;

        PlayerLogic.PlayerDiedEvent += () => { countOfGames++; Debug.Log($"count of games {countOfGames}"); } ;
        BossFightPhase2.Boss.BossDiedEvent += () => { countOfGames++; Debug.Log($"count of games {countOfGames}"); } ;

        instance = this;
    }

    public static GamesCount GetInstance()
    {
        if (instance == null)
            new GamesCount();

        return instance;
    }
    #endregion

    public override void Registrate()
    {
        PlayerLogic.PlayerDiedEvent += () => { countOfGames++; Debug.Log($"count of games {countOfGames}"); };
        BossFightPhase2.Boss.BossDiedEvent += () => { countOfGames++; Debug.Log($"count of games {countOfGames}"); };
    }
}
