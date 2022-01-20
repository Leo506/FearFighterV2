using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour, IObserver
{
    [SerializeField] Subject subject;

    /// <summary>
    /// Доступен ли выход
    /// </summary>
    public bool available { get; private set; }

    private void Start()
    {
        available = false;
        subject.AddObserver(this);
    }

    public void OnNotify(EventList eventValue)
    {
        if (eventValue == EventList.NO_ENEMIES)
            available = true;
    }


    /// <summary>
    /// Запрос на переход на следующий уровень
    /// </summary>
    public void GoNextLvl()
    {
        subject.Notify(EventList.NEXT_LVL);
    }

}
