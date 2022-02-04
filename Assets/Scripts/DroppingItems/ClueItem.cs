using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueItem : DroppingObj
{
    protected override void OnGet()
    {
        Sprite sprite = GetComponentInChildren<SpriteRenderer>().sprite;
        int id = DroppingObjController.countOfClues;
        InventoryItem item = new InventoryItem(sprite, () => {
            if (GameController.lvlNumber == 4)
            {
                FindObjectOfType<DialogController>().StartDialog(id);
                Time.timeScale = 1;
                InventoryController.instance.RemoveItem($"ClueItem{id}");
            }
        }, $"ClueItem{id}");
        DroppingObjController.countOfClues++;
        InventoryController.instance.AddItem(item);
        Debug.Log("Get a clue with id " + id);
        Destroy(this.gameObject);
    }
}
