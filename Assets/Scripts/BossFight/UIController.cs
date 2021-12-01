using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text bossText;
    [SerializeField] BossTextLoader loader;

    Queue<string> requireIDs = new Queue<string>();  // Очередь со всеми id, которые нужно показать

    bool isShowing = false;


    void Start() {
    	StartCoroutine(WaitUntilLoad());
    }


    /// <summary>Добавляет id к списку id'шников, которые нужно показать</summary>
    /// <param name="id">id фразы</param>
    public void RegisterNextID(string id) {

    	requireIDs.Enqueue(id);

    	if (!isShowing && loader.isLoaded)
    		StartShow();
    }



    /// <summary>Начать вывод фраз</summary>
    public void StartShow() {
    	if (requireIDs.Count != 0)
    		ShowPhrase(requireIDs.Dequeue());
    }

    /// <summary>Препывает вывол фраз</summary>
    public void StopShow() {
    	StopAllCoroutines();
    }


    /// <summary>Показывает следующую фразу босса</summary>
    /// <param name="phraseID">ID фразы</param>
    public void ShowPhrase(string phraseID) {

    	if (loader.isLoaded) {
    		string text = loader.bossText[phraseID];

    		StartCoroutine(Show(text));
    	}

    }

    IEnumerator Show(string text) {

    	isShowing = true;
    	
    	string tmp = "";
    	foreach (var item in text) {
    		tmp += item;
    		bossText.text = tmp;
    		yield return new WaitForSeconds(0.1f);
    	}

    	if (requireIDs.Count != 0)
    		ShowPhrase(requireIDs.Dequeue());
    	else
    		isShowing = false;
    }


    IEnumerator WaitUntilLoad() {
    	yield return new WaitUntil(() => loader.isLoaded);
    	if (requireIDs.Count != 0)
    		ShowPhrase(requireIDs.Dequeue());
    }
}
