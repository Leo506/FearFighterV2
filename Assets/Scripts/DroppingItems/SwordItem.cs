using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordItem : DroppingObj
{

    protected override void OnGet()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        InventoryItem item = new InventoryItem(sprite, () => {}, "SwordItem");
        InventoryController.instance.AddItem(item);
        Destroy(this.gameObject);
    }
}
