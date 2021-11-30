using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text bossText;
    [SerializeField] BossTextLoader loader;

    int currentPhrase = 0;

    void Start() {
    	StartCoroutine(WaitUntilLoad());
    }

    public void ShowPhrase() {
    	if (loader.isLoaded) {
    		string text;
    		if (currentPhrase == 0)
    			text = loader.bossText["_StartDialog"];
    		else if (currentPhrase < loader.bossText.Count)
    			text = loader.bossText[$"_Clue{currentPhrase}"];
    		else
    			text = "...";

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


    IEnumerator WaitUntilLoad() {
    	yield return new WaitUntil(() => loader.isLoaded);
    	ShowPhrase();
    }
}
