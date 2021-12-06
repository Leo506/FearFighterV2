using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InventoryData))]
public class InventoryUI : MonoBehaviour
{
    [SerializeField] Canvas inventoryCanvas;
    [SerializeField] float minX = -300;
    [SerializeField] float maxX = 300;
    [SerializeField] float minY = -200;
    [SerializeField] float maxY = 200;

    [SerializeField] int itemsPerLine = 3;

    [SerializeField] Font font;

    InventoryData data;

    private void Start()
    {
        data = GetComponent<InventoryData>();
    }
    public void UpdateInventoryShow()
    {
        Debug.Log("Inventory count: " + InventoryController.inventory.Count);
        int i = 0;
        foreach (var item in InventoryController.inventory.Keys)
        {
            RectTransform rect = CreateImageForItem(InventoryController.inventory.Count, i, data.itemsSprites[item]);
            CreateTextForItem(rect, InventoryController.inventory[item]);
            i++;
        }
    }


    RectTransform CreateImageForItem(int countOfItems, int itemIndex, Sprite sprite)
    {
        float offsetX = (maxX - minX) / (itemsPerLine - 1);
        float offsetY = (maxY - minY) / (itemsPerLine - 1);

        int Yindex = itemIndex / itemsPerLine;

        Vector2 pos = new Vector2(itemIndex * offsetX + minX, Yindex * offsetY + maxY);
        Debug.Log("offset x: " + offsetX);
        Debug.Log("offset: y" + offsetY);
        Debug.Log("Yindex: " + Yindex);
        Debug.Log(pos);

        Image image = new GameObject().AddComponent<Image>();
        image.transform.parent = inventoryCanvas.transform;
        image.transform.localPosition = pos;
        image.sprite = sprite;
        image.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        return image.rectTransform;

    }


    void CreateTextForItem(RectTransform rect, int count)
    {
        Vector2 pos = new Vector2(rect.localPosition.x + rect.rect.width / 4, rect.localPosition.y - rect.rect.height / 4);

        Text text = new GameObject().AddComponent<Text>();
        text.transform.parent = inventoryCanvas.transform;
        text.transform.localPosition = pos;
        text.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        text.font = font;
        text.text = $"x{count}";
        text.color = Color.red;
        text.fontSize = 50;
        text.alignment = TextAnchor.MiddleCenter;
    }
}
