using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourcesSave : ISaveable
{
    int money = MoneyController.Money;
    int exp = ExpController.Exp;

    public void Load()
    {
        MoneyController.Money = money;
        ExpController.Exp = exp;
    }
}
