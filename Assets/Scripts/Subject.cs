using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EventList
{
    ENEMY_DIED
}

public class Subject : MonoBehaviour
{
    List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(GameObject obj, EventList eventValue)
    {
        foreach (var item in observers)
        {
            item.OnNotify(obj, eventValue);
        }
    }
}
