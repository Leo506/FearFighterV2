using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    /// <summary>
    /// Запрос на переход на следующий уровень
    /// </summary>
    public void GoNextLvl()
    {
        Subject.instance.Notify(EventList.NEXT_LVL);
    }

}
