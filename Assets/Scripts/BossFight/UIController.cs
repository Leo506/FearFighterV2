using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BossFight
{
	public class UIController : MonoBehaviour
	{
	    [SerializeField] Text bossText;
	    public bool canLoad2Phase = false;

	    Queue<string> requireIDs = new Queue<string>();  // Очередь со всеми id, которые нужно показать

	    bool isShowing = false;

		PhraseResource phrase;


	    void Start() {
	    	StartCoroutine(WaitUntilLoad());
	    }


	    /// <summary>Добавляет id к списку id'шников, которые нужно показать</summary>
	    /// <param name="id">id фразы</param>
	    public void RegisterNextID(string id) {

	    	requireIDs.Enqueue(id);

	    	if (!isShowing && phrase != null)
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
	    public void ShowPhrase(string phraseID) 
		{
			if (phrase != null)
			{
	    		string text = phrase.text[phraseID];

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
	    	{
	    		isShowing = false;
	    		if (canLoad2Phase)
	    			SceneManager.LoadScene("BossFightPhase2");
	    	}

	    }


	    IEnumerator WaitUntilLoad() {
			string path = "";
			#if UNITY_EDITOR
	        	path = "file://" + Application.streamingAssetsPath + $"/BossStrings/Boss0.xml";
			#else
	        	path = "jar:file://" + Application.dataPath + $"!/assets/BossStrings/Boss0.xml";
			#endif

	    	ResourceManager manager = new ResourceManager();

			if (!manager.ResourceLoaded(ResourceType.TEXT_RES, path))
				yield return manager.LoadResource(ResourceType.TEXT_RES, path);

			phrase = new PhraseResource();
			phrase.text = (manager.GetResource(ResourceType.TEXT_RES, path) as PhraseResource).text;
			Debug.Log("phrase length: " + phrase.text.Count);

	    	if (requireIDs.Count != 0)
	    		ShowPhrase(requireIDs.Dequeue());
	    }
	}
}
