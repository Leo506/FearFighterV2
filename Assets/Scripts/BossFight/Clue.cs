using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace BossFight
{
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
	        target.GetComponent<Image>().enabled = false;

	        // Возвращаем прежний размер, тк игрок перестал передвигать улику
	        transform.localScale = new Vector3(1, 1, 1);

	    	
	    	if (CheckPos(transform.position))
	        {
	            // Пытаемся атаковать босса
	            if (boss.TryAttack(clueID))
	                Destroy(this.gameObject);
	        }

	    	// Если не попали на цель, то возвращаем улику на своё место
	    	transform.localPosition = startPos;
	    }


	    public void OnPointerDown(PointerEventData eventData) {
	    	Debug.Log("Pointer down");

	    	// Увеличиваем размер улики, чтобы показать, что она выбрана
	    	transform.localScale = new Vector3(1.5f, 1.5f, 1);

	        target.GetComponent<Image>().enabled = true;
	    }


	    // Проверяем, попала ли улика на объект, на который нужно её перенести
	    // Сначала проверяем координаты по Х,
	    // потом по Y
	    bool CheckPos(Vector3 pos)
	    {
	        if (pos.x >= target.position.x - target.rect.width / 2 && pos.x <= target.position.x + target.rect.width / 2)
	        {
	            if (pos.y >= target.position.y - target.rect.height / 2 && pos.y <= target.position.y + target.rect.height / 2)
	            {

	                return true;
	            }
	        }

	        return false;
	    }
	}
}