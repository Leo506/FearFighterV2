using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : DroppingObj
{

    protected override void OnGet()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        InventoryItem item = new InventoryItem(sprite, () => {

            if (InventoryController.instance.GetItemNumber("HealthItem") != 0)
            {
                PlayerLogic.instance.CurrentHP += 10;
                Debug.Log("+ 10 HP !!!");
                InventoryController.instance.RemoveItem("HealthItem");
            }
                
        }, "HealthItem");
        InventoryController.instance.AddItem(item);
        Destroy(this.gameObject);
    }
}
