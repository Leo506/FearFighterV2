using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clue : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	[SerializeField] Canvas canvas;         // Canvas, в котором происходит перемещение объекта
	[SerializeField] RectTransform target;  // Куда нужно перетащить объект
	[SerializeField] UIController uiController;

	Vector3 startPos;

    private RectTransform rectTransform;

    private void Awake() {
    	rectTransform = GetComponent<RectTransform>();
    	startPos = transform.localPosition;
    }


    public void OnBeginDrag(PointerEventData eventData) {
    	Debug.Log("Begin drag");
    }


    public void OnDrag(PointerEventData eventData) {
    	Debug.Log("On drag");
    	rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }


    public void OnEndDrag(PointerEventData eventData) {
    	Debug.Log("End drag");
    	transform.localScale = new Vector3(1, 1, 1);

    	if (transform.position.x >= target.position.x - target.rect.width / 2 && transform.position.x <= target.position.x + target.rect.width / 2) {
    		if (transform.position.y >= target.position.y - target.rect.height / 2 && transform.position.y <= target.position.y + target.rect.height / 2) {
    			uiController.ShowPhrase();
    			Destroy(this.gameObject);
    		}
    	}

    	transform.localPosition = startPos;
    }


    public void OnPointerDown(PointerEventData eventData) {
    	Debug.Log("Pointer down");
    	transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }
}
