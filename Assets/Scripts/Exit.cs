using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public static event System.Action OnNextLvlEvent;

    /// <summary>
    /// Запрос на переход на следующий уровень
    /// </summary>
    public void GoNextLvl()
    {
        OnNextLvlEvent?.Invoke();
    }

}
