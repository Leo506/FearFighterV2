using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.Networking;
using System.Globalization;

namespace BossFight
{
	public class BossTextLoader : MonoBehaviour
	{

	    public Dictionary<string, string> bossText = new Dictionary<string, string>();
	    public bool isLoaded { get; private set; }

	    void Start() {
	    	LoadBossText(0);
	    	isLoaded = false;
	    }

	    public void LoadBossText(int bossId) {
	    	string path;
	#if UNITY_EDITOR
	        path = "file://" + Application.streamingAssetsPath + $"/BossStrings/Boss0.xml";
	#else
	        path = "jar:file://" + Application.dataPath + $"!/assets/BossStrings/Boss0.xml";
	#endif   
	    	StartCoroutine(LoadTextFromFile(bossId, path));
	    }

	    IEnumerator LoadTextFromFile(int id, string path) {
	    	UnityWebRequest uwr;
	    	using (uwr = UnityWebRequest.Get(path)) {
	    		yield return uwr.SendWebRequest();
	    		if (uwr.isNetworkError || uwr.isHttpError)
	    			Debug.Log(uwr.error);
	    		else {
	    			XmlDocument bossDoc;
	    			bossDoc = new XmlDocument();
	    			var tmp = uwr.downloadHandler.text;

	    			string byteOrderMarkUtf8 = System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetPreamble());
			        if (tmp.StartsWith(byteOrderMarkUtf8)) {
			            tmp = tmp.Remove(0, byteOrderMarkUtf8.Length-1);
			        }

			        bossDoc.LoadXml(tmp);


	    			XmlElement text = bossDoc.DocumentElement;  // Корневой элемент

	    			if (text != null) {
	    				foreach (XmlElement txt in text) {
	    					var textId = txt.Attributes.GetNamedItem("id").Value;
	    					var textValue = txt.InnerText;

	    					Debug.Log("id: " + textId + " value: " + textValue);

	    					bossText.Add(textId, textValue);
	    				}

	    				isLoaded = true;
	    			}
	    		}
	    	}
	    }
	}
}
