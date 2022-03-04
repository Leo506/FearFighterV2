using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController
{
    static int exp = 0;  // Кол-во опыта у игрока


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

        private set
        {
            if (value >= 0)
                exp = value;
        }
    }
}
