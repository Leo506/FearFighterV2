using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clue : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
	[SerializeField] Canvas canvas;              // Canvas, в котором происходит перемещение объекта
	[SerializeField] RectTransform target;       // Куда нужно перетащить объект
	[SerializeField] Boss boss;                  // Объект босса
	public int clueID;                 			 // ID улики

	Vector3 startPos;

    private RectTransform rectTransform;

    private void Awake() {

    	rectTransform = GetComponent<RectTransform>(); // Получаем компонент RectTransform, через который будем перемещать улику

    	startPos = transform.localPosition;            // Запоминаем изначальную позицию улики
    }


    public void OnDrag(PointerEventData eventData) {
    	Debug.Log("On drag");
    	rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;  // Перемещаем улику куда укажет игрок
    }


    public void OnEndDrag(PointerEventData eventData) {
    	Debug.Log("End drag");

    	// Возвращаем прежний размер, тк игрок перестал передвигать улику
    	transform.localScale = new Vector3(1, 1, 1);

    	// Проверяем, попала ли улика на объект, на который нужно её перенести
    	// Сначала проверяем координаты по Х,
    	// потом по Y
    	if (transform.position.x >= target.position.x - target.rect.width / 2 && transform.position.x <= target.position.x + target.rect.width / 2) {
    		if (transform.position.y >= target.position.y - target.rect.height / 2 && transform.position.y <= target.position.y + target.rect.height / 2) {
    			
    			// Пытаемся атаковать босса
    			if (boss.TryAttack(clueID))   
    				Destroy(this.gameObject);
    		}
    	}

    	// Если не попали на цель, то возвращаем улику на своё место
    	transform.localPosition = startPos;
    }


    public void OnPointerDown(PointerEventData eventData) {
    	Debug.Log("Pointer down");

    	// Увеличиваем размер улики, чтобы показать, что она выбрана
    	transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }
}
