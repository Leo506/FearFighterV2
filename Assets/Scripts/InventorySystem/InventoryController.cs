using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryData))]
public class InventoryController : MonoBehaviour, ISetUpObj, IObserver
{
    Subject subject;
    public static Dictionary<int, int> inventory { get; private set; }
    InventoryData data;

    public void SetUp()
    {
        subject = FindObjectOfType<Subject>();
        subject.AddObserver(this);
        inventory = new Dictionary<int, int>();
        data = GetComponent<InventoryData>();
    }


    public void OnNotify(GameObject gameObject, EventList eventValue)
    {
        if (eventValue == EventList.ITEM_GET)
        {
            int type = gameObject.GetComponent<DroppingObj>().itemType;

            if (inventory.ContainsKey(type))
                inventory[type] += 1;
            else
                inventory.Add(type, 1);
        }
    }
}
