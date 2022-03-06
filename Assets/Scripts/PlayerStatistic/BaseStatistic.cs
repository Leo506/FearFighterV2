using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatistic : MonoBehaviour, IStatisticData
{
    protected PlayerStatistic playerStatistic;

    // Реализация интерфейса и логики подписки/отписки от событий
    #region 
    protected void Awake()
    {
        playerStatistic = GetComponent<PlayerStatistic>();
        Register();
    }


    protected void OnDestroy()
    {
        UnRegister();
    }

    public void Register() 
    {
        playerStatistic.AddStatistic(this);
        Subscribe();
    }

    public void UnRegister()
    {
        playerStatistic.RemoveStatistic(this);
        Unsubscribe();
    }

    public object GetValue()
    {
        return GetMyValue();
    }

    public void SetValue(object value)
    {
        SetMyValue(value);
    }
    #endregion

    protected virtual object GetMyValue()
    {
        return null;
    }

    protected virtual void Subscribe()
    {}

    protected virtual void Unsubscribe()
    {}

    protected virtual void SetMyValue(object value)
    { }
}
