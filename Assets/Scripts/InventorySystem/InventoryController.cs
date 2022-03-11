using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController
{
    public static Dictionary<InventoryItem, int> inventory { get; private set; }
    private static InventoryController instance;

    private InventoryController()
    {
        inventory = new Dictionary<InventoryItem, int>();
    }

    public static InventoryController GetInstance()
    {
        if (instance == null)
            instance = new InventoryController();

        return instance;
    }



    /// <summary>
    /// Добавляет новый предмет в инвентарь
    /// </summary>
    /// <param name="item">Объект для добавления</param>
    public void AddItem(InventoryItem item)
    {
        foreach (var it in inventory)
        {
            if (it.Key.id == item.id)
            {
                inventory[it.Key]++;
                return;
            }
        }

        inventory.Add(item, 1);

        Debug.Log("Add item with " + item.id + " id" + " and " + item.usingFunction);
    }


    /// <summary>
    /// Удаляет единицу предмета из инвентаря
    /// </summary>
    /// <param name="id">id предмета</param>
    public void RemoveItem(string id)
    {
        InventoryItem itemForRemove = null;

        foreach (var item in inventory)
        {
            if (item.Key.id == id)
            {
                itemForRemove = item.Key;
                break;
            }
        }

        inventory[itemForRemove]--;
        if (inventory[itemForRemove] <= 0)
            inventory.Remove(itemForRemove);
    }


    /// <summary>
    /// Количество определённого предмета в инвентаре
    /// </summary>
    /// <param name="id">id предмета</param>
    /// <returns>Количество предмета</returns>
    public int GetItemNumber(string id)
    {
        foreach (var item in inventory)
        {
            if (item.Key.id == id)
                return item.Value;
        }

        return 0;
    }


    /// <summary>
    /// Возвращает список различных предметов в инвенторе игрока
    /// </summary>
    /// <returns></returns>
    public List<InventoryItem> GetItems()
    {
        List<InventoryItem> items = new List<InventoryItem>();
        foreach (var item in inventory)
            items.Add(item.Key);
        
        return items;
    }
}
