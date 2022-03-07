using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamesCount : StatisticData
{
    public int countOfGames { get; private set; }  // Кол-во сыгранных игр


    public GamesCount()
    {
        countOfGames = 0;

        Registrate();

    }

    public void Registrate()
    {
        PlayerLogic.PlayerDiedEvent += () => { countOfGames++; Debug.Log($"count of games {countOfGames}"); };
        BossFightPhase2.Boss.BossDiedEvent += () => { countOfGames++; Debug.Log($"count of games {countOfGames}"); };
    }
}
