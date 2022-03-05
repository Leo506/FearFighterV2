using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatistic))]
public class GotDamage : MonoBehaviour, IStatisticData
{
    PlayerStatistic playerStatistic;
    private static float gotDamage = 0;


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
        PlayerLogic.PlayerGotDamage += UpdateStatistic;
    }

    public void UnRegister()
    {
        playerStatistic.RemoveStatistic(this);
        PlayerLogic.PlayerGotDamage -= UpdateStatistic;
    }

    public object GetValue()
    {
        return gotDamage;
    }


    public void UpdateStatistic(float value)
    {
        gotDamage += value;
        Debug.Log($"GotDamage {gotDamage}");
    }
}
