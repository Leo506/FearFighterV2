using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController
{
    static int exp = 0;  // Кол-во опыта у игрока

    /// <summary>
    /// Событие вызывается, когда меняется значение опыта игрока
    /// </summary>
    public static event System.Action ExpChanged;

    /// <summary>
    /// Количество опыта у игрока
    /// </summary>
    /// <value></value>
    public static int Exp
    {
        get
        {
            return exp;
        }

        set
        {
            if (value >= 0)
            {
                exp = value;
                ExpChanged?.Invoke();
            }
        }
    }
}
