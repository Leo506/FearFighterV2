using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatistic))]
public class GamesCount : MonoBehaviour, IStatisticData
{
    PlayerStatistic playerStatistic;
    private static int countOfGames = 0;


    private void Awake() 
    {
        playerStatistic = GetComponent<PlayerStatistic>();
        Register();    
    }

    private void OnDestroy() 
    {
        UnRegister();
    }

    public void Register()
    {
        // Регистрируемся у PlayerStatistic
        playerStatistic.AddStatistic(this);
        PlayerLogic.PlayerDiedEvent += UpdateStatistic;
        BossFightPhase2.Boss.BossDiedEvent += UpdateStatistic;

    }

    public void UnRegister()
    {
        playerStatistic.RemoveStatistic(this);
        PlayerLogic.PlayerDiedEvent -= UpdateStatistic;
        BossFightPhase2.Boss.BossDiedEvent -= UpdateStatistic;
    }

    public object GetValue()
    {
        return countOfGames;
    }


    public void UpdateStatistic()
    {
        countOfGames++;
        Debug.Log($"CountOfGames {countOfGames}");
    }
}
