using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueItem : DroppingObj
{
    protected override void OnGet()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        int id = DroppingObjController.countOfClues;
        InventoryItem item = new InventoryItem(sprite, () => {
            if (GameController.lvlNumber == 4)
            {
                FindObjectOfType<DialogController>().StartDialog(id);
                Time.timeScale = 1;
                InventoryController.instance.RemoveItem($"ClueItem{id}");
                Subject.instance.Notify(EventList.ITEM_USED);
            }
        }, $"ClueItem{DroppingObjController.countOfClues}");
        DroppingObjController.countOfClues++;
        InventoryController.instance.AddItem(item);
        Destroy(this.gameObject);
    }
}
