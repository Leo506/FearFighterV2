using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Entities;

public class ProgressSystem
{
    public InventoryController inventory { get; private set; }

    public Stats playerStats { get; private set; }
    
    public Stats currentStats { get; private set; }  // Текущие статы


    // Реализация синглтона
    #region 
    private static ProgressSystem instance; 
    private ProgressSystem()
    {
        inventory = InventoryController.GetInstance();
        playerStats = new Stats();
        currentStats = playerStats;
    }

    public static ProgressSystem GetInstance()
    {
        if (instance == null)
            instance = new ProgressSystem();

        return instance;
    }
    #endregion

    public void CalculateStats()
    {
        currentStats = playerStats;

        foreach (var item in inventory.GetItems())
        {
            IHaveEffect effectItem = item as IHaveEffect;
            if (effectItem != null)
                currentStats += effectItem.GetEffect();
        }
    }

    public void SetStats(Stats stats)
    {
        currentStats = stats;
    }
}
