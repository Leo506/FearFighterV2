using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : DroppingObj
{
    protected override void OnGet()
    {
        Sprite sprite = GetComponentInChildren<SpriteRenderer>().sprite;
        InventoryItem item = new InventoryItem(sprite, () => {}, "MoneyItem");
        InventoryController.instance.AddItem(item);
        Destroy(this.gameObject);
    }
}
