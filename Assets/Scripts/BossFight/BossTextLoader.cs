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

	    public List<Question> bossText = new List<Question>();
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
	    				foreach (XmlElement question in text) 
						{
	    					var qId = question.Attributes.GetNamedItem("id").Value;                  // Ищем id вопроса
							var qText = question.Attributes.GetNamedItem("text").Value.ToString();  // Получаем его текст
							
							// Заполняем список ответами
							List<string> answers = new List<string>();
							string right = "";  // Заготовка для верного ответа

							// Проходим по всем тегам Answer
							foreach	(XmlElement item in question)
							{
								answers.Add(item.InnerText);

								// Запоминаем верный ответ
								if (item.Attributes.GetNamedItem("isRight").Value == "1")
									right = item.InnerText;
							}

							Question q;
							q.id = int.Parse(qId);
							q.questionText = qText;
							q.answers = answers;
							q.rightAnswer = right;

	    					bossText.Add(q);
							Debug.Log(q);
	    				}

	    				isLoaded = true;
	    			}
	    		}
	    	}
	    }
	}
}
