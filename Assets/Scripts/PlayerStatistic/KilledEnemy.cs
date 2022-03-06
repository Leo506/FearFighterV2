using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledEnemy : BaseStatistic
{
    private static int countOfKilledEnemy = 0;

    protected override object GetMyValue()
    {
        return countOfKilledEnemy;
    }

    protected override void Subscribe()
    {
        base.Subscribe();
        EnemyController.EnemyDiedEvent += UpdateStatistic;
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();
        EnemyController.EnemyDiedEvent -= UpdateStatistic;
    }

    void UpdateStatistic()
    {
        countOfKilledEnemy++;
        Debug.Log($"Count of killed enemies: {countOfKilledEnemy}");
    }
}
