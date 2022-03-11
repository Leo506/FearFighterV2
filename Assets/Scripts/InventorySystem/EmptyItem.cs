using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Entities;
using UnityEngine.Events;

[System.Serializable]
public class EmptyItem : InventoryItem, IHaveEffect
{
    public EmptyItem(Sprite sprite, UnityAction func, string id) : base(sprite, func, id)
    {
        
    }

    public Stats GetEffect()
    {
        return new Stats(10, 10, 10, 10, 10, 10);
    }
}
