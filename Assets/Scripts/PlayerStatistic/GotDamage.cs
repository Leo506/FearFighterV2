using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotDamage : BaseStatistic
{
    private static float gotDamage = 0;


    protected override void Subscribe()
    {
        PlayerLogic.PlayerGotDamage += UpdateStatistic;
    }

    protected override void Unsubscribe()
    {
        PlayerLogic.PlayerGotDamage -= UpdateStatistic;
    }

    protected override object GetMyValue()
    {
        return gotDamage;
    }


    void UpdateStatistic(float value)
    {
        gotDamage += value;
        Debug.Log($"GotDamage {gotDamage}");
    }
}
