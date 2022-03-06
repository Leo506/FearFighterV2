using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesCount : BaseStatistic
{
    private static int countOfGames = 0;


    protected override void Subscribe()
    {
        PlayerLogic.PlayerDiedEvent += UpdateStatistic;
        BossFightPhase2.Boss.BossDiedEvent += UpdateStatistic;

    }

    protected override void Unsubscribe()
    {
        PlayerLogic.PlayerDiedEvent -= UpdateStatistic;
        BossFightPhase2.Boss.BossDiedEvent -= UpdateStatistic;
    }

    protected override object GetMyValue()
    {
        return countOfGames;
    }


    void UpdateStatistic()
    {
        countOfGames++;
        Debug.Log($"CountOfGames {countOfGames}");
    }

    protected override void SetMyValue(object value)
    {
        int? tmp = value as int?;
        if (tmp != null)
            countOfGames = tmp.Value;
    }
}
