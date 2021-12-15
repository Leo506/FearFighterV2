using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.Networking;


// Типы ресурсов
public enum ResourceType 
{
	SCENE_RES,
	TEXT_RES,
	MUSIC_RES,
	AUDIO_RES
}


public class ResourceManager
{
	static Dictionary<ResourceType, List<IResource>> loadedResources = new Dictionary<ResourceType, List<IResource>>();  // Словарь с загруженными ресурсами (тип : ресурс)


	/// <summary>Загружает требуемый ресурс</summary>
	/// <param name="type">Тип ресурса</param>
	/// <param name="id">id ресурса (id - путь к файлу ресурса)</param>
    public IEnumerator LoadResource(ResourceType type, string id)
    {
    	switch (type)
    	{
    		case ResourceType.SCENE_RES:

    			// Загружаем xml файл сцены с определенным id
    			string tmp = "";
				UnityWebRequest uwr;
				using (uwr = UnityWebRequest.Get(id))
				{
					yield return uwr.SendWebRequest();
					if (uwr.isNetworkError || uwr.isHttpError)
						Debug.Log(uwr.error);
					else
						tmp = uwr.downloadHandler.text;
				}

				SceneResource map = XMLParser.MapHandler(tmp);
				map.SetID(id);
				
				AddToLoadedResource(ResourceType.SCENE_RES, map);
					
				Debug.Log("Загруженна карта");
    			
    			break;

    		case ResourceType.TEXT_RES:

    			// Загружаем xml файл с текстом с определенным id
				tmp = "";
				
				using (uwr = UnityWebRequest.Get(id))
				{
					yield return uwr.SendWebRequest();
					if (uwr.isNetworkError || uwr.isHttpError)
						Debug.Log(uwr.error);
					else
						tmp = uwr.downloadHandler.text;
				}

				PhraseResource phrase = XMLParser.PhraseHandler(tmp);
				phrase.SetID(id);
				
				AddToLoadedResource(ResourceType.TEXT_RES, phrase);
					
				Debug.Log("Загружены слова");
    			break;

    		case ResourceType.MUSIC_RES:
    			// Загружаем файл с фоновой музыкой
    			break;

    		case ResourceType.AUDIO_RES:
    			// Загружаем аудиоэффекты
    			break;

    		default:
    			break;
    	}
    }


    /// <summary>Получение необходимого ресурса</summary>
    /// <param name="type">Тип ресурса</param>
    /// <param name="id">id ресурса</param>
    /// <returns>IResource</returns>
    public IResource GetResource(ResourceType type, string id)
    {
		if (loadedResources.ContainsKey(type))
		{
    		foreach	(var item in loadedResources[type])
			{
				if (item.GetID() == id)
					return item;
			}
		}

		return null;
    }


    /// <summary>Возвращает все загруженные ресурсы определенного типа</summary>
    /// <param name="type">Тип ресурса</param>
    /// <returns>Список ресурсов определенного типа<IResource></returns>
    public List<IResource> GetResource(ResourceType type)
    {
    	if (loadedResources.ContainsKey(type))
			return loadedResources[type];

    	return new List<IResource>();
    }


	/// <summary>Проверяет, загружен ли ресурс</summary>
    /// <param name="type">Тип ресурса</param>
	/// <param name="id">id ресурса</param>
    /// <returns>Загружен ли ресурс</returns>
	public bool ResourceLoaded(ResourceType type, string id)
	{
		var res = GetResource(type, id);

		return res != null;
	}


	/// <summary>Добавляет ресурс в словарь с загруженныеми ресурсами</summary>
	/// <param name="type">Тип ресурса</param>
	/// <param name="res">Ресурс</param>
	void AddToLoadedResource(ResourceType type, IResource res)
	{
		if (loadedResources.ContainsKey(type))
			loadedResources[type].Add(res);

		else
		{
			loadedResources.Add(type, new List<IResource>());
			loadedResources[type].Add(res);
		}
	}
}
