using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loading {
	public class Map : MonoBehaviour, IObserver
	{
		[SerializeField] Subject subject;

	    void Awake() {
            foreach (var item in FindObjectsOfType<Map>())
            {
				if (item != this)
					Destroy(item.gameObject);
            }
	    	DontDestroyOnLoad(this.gameObject);
	    	subject.AddObserver(this);
	    }


	    public void OnNotify(EventList eventValue) {
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
