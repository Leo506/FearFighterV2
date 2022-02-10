using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loading {
	public class Map : MonoBehaviour
	{
	    void Awake() {
            foreach (var item in FindObjectsOfType<Map>())
            {
				if (item != this)
					Destroy(item.gameObject);
            }
	    	DontDestroyOnLoad(this.gameObject);
	    }
	}
}
