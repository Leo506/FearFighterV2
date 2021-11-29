using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text bossText;
    [SerializeField] BossTextLoader loader;

    int currentPhrase = 0;

    void Update() {
    	if (Input.GetMouseButtonDown(0)) {
    		if (loader.isLoaded) {
    			StopAllCoroutines();
    			ShowPhrase();
    		}
    	}
    }

    public void ShowPhrase() {
    	if (loader.isLoaded) {
    		string text;
    		if (currentPhrase == 0)
    			text = loader.bossText["_StartDialog"];
    		else
    			text = loader.bossText[$"_Clue{currentPhrase}"];

    		StartCoroutine(Show(text));

    		currentPhrase++;
    	}
    }

    IEnumerator Show(string text) {
    	string tmp = "";
    	foreach (var item in text) {
    		tmp += item;
    		bossText.text = tmp;
    		yield return new WaitForSeconds(0.1f);
    	}
    }
}
