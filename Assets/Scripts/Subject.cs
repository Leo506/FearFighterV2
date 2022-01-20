using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EventList
{
    ENEMY_DIED,
    MAP_READY,
    GAME_READY_TO_START,
    ITEM_GET,
    NO_ENEMIES,
    NEXT_LVL,
    GAME_OVER,
    VICTORY,
    ITEM_USED
}

public class Subject : MonoBehaviour
{
    List<IObserver> observers = new List<IObserver>();
    public static Subject instance;

    private void Awake() 
    {
        if (instance != this && instance != null)
            Destroy(instance.gameObject);
        instance = this;   
    }


    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
        Debug.Log("Count of observers: " + observers.Count);
    }


    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }


    public void Notify(EventList eventValue)
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i]?.OnNotify(eventValue);
        }
    }
}
