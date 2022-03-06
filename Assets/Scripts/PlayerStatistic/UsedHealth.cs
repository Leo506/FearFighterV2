using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedHealth : BaseStatistic
{
    private static int countOfUsedHealth = 0;
    protected override object GetMyValue()
    {
        return countOfUsedHealth;
    }

    protected override void Subscribe()
    {
        base.Subscribe();
        HealthItem.HealthUsedEvent += UpdateStatistic; 
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();
        HealthItem.HealthUsedEvent -= UpdateStatistic;
    }

    void UpdateStatistic()
    {
        countOfUsedHealth++;
    }

    protected override void SetMyValue(object value)
    {
        int? tmp = value as int?;
        if (tmp != null)
            countOfUsedHealth = tmp.Value;
    }
}
