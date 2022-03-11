using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[System.Serializable]
public class InventoryItem
{
    [SerializeField]
    public Sprite sprite { get; private set; }               // Спрайт объект
    public UnityAction usingFunction { get; private set; }   // Функция использования

    public string id { get; private set; }

    public static event System.Action ItemUsedEvent;


    /// <summary>
    /// Создаёт новый объект для добавления в инвентарь
    /// </summary>
    /// <param name="sprite">Спрайт объекта</param>
    /// <param name="func">Функция использования объекта</param>
    /// <param name="id">id объекта</param>
    public InventoryItem(Sprite sprite, UnityAction func, string id)
    {
        this.sprite = sprite;
        this.usingFunction += func;
        this.id = id;
    }


    /// <summary>
    /// Использует предмет 
    /// </summary>
    public void UseItem()
    {
        usingFunction();
        ItemUsedEvent?.Invoke();
    }
}
