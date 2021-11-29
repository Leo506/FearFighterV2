using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loading {
	public class Map : MonoBehaviour, IObserver
	{
		[SerializeField] Subject subject;

	    void Awake() {
	    	DontDestroyOnLoad(this.gameObject);
	    	subject.AddObserver(this);
	    }


	    public void OnNotify(GameObject obj, EventList eventValue) {
	    	if (eventValue == EventList.GAME_READY_TO_START)
	    		//StartCoroutine(Wait());
	    		SceneManager.LoadScene("SampleScene");
	    }

	    IEnumerator Wait() {
	    	yield return new WaitForSeconds(3);
	    	SceneManager.LoadScene("SampleScene");
	    }
	}
}
