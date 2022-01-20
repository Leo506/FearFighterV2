using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueItem : DroppingObj
{
    protected override void OnGet()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        InventoryItem item = new InventoryItem(sprite, () => {}, "ClueItem");
        InventoryController.instance.AddItem(item);
        Destroy(this.gameObject);
    }
}
