using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(InventoryData))]
public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject content;

    [SerializeField] Font font;
    [SerializeField] GameObject inventoryImagePrefab;

    private void Start() 
    {
        InventoryItem.ItemUsedEvent += UpdateInventoryShow; 
    }

    
    void OnDestroy()
    {
        InventoryItem.ItemUsedEvent -= UpdateInventoryShow;
    }


    /// <summary>
    /// Обновляет вид инвентаря
    /// </summary>
    public void UpdateInventoryShow()
    {
        ClearUI();

        for (int i = 0; i < InventoryController.inventory.Count; i++)
        {
            if (i > 2)
                ScaleContentSize();

            InventoryItem item = InventoryController.inventory.ElementAt(i).Key;  // Получаем объект
            
            // Создаём новый экземпляр объекта в инвентаре
            var image = Instantiate(inventoryImagePrefab, content.transform);
            
            // Устанавливаем его позицию
            image.transform.localPosition = new Vector2(91.5f, -100 * i - 76);

            // Устанавливаем спрайт и действие при нажатии
            image.GetComponent<Image>().sprite = item.sprite;
            image.GetComponent<Button>().onClick.AddListener(item.UseItem);

            // Устанавливаем текст количества предмета
            image.GetComponentInChildren<Text>().text = InventoryController.inventory.ElementAt(i).Value.ToString();

        }
    }


    void ScaleContentSize()
    {
        Rect rect = content.GetComponent<RectTransform>().rect;
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, rect.size.y + 100);
    }


    void ClearUI()
    {
        for(int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
    }
}
