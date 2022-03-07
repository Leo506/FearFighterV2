using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class StatisticData
{
    /// <summary>
    /// Объект регистрируется на необходимые ему события
    /// </summary>
    public abstract void Registrate();
}
