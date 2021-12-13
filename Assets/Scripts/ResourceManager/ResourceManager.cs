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
	static Dictionary<ResourceType, IResource> loadedResources = new Dictionary<ResourceType, IResource>();  // Словарь с загруженными ресурсами (тип : ресурс)


	/// <summary>Загружает требуемый ресурс</summary>
	/// <param name="type">Тип ресурса</param>
	/// <param name="id">id ресурса</param>
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
				
				if (loadedResources.ContainsKey(ResourceType.SCENE_RES))
					loadedResources[ResourceType.SCENE_RES] = map;

				else
					loadedResources.Add(ResourceType.SCENE_RES, map);
					
				Debug.Log("Загруженна карта");
    			
    			break;

    		case ResourceType.TEXT_RES:
    			// Загружаем xml файл с текстом с определенным id
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
    	foreach (var item in loadedResources.Keys)
    	{
    		if (loadedResources[item].GetResType() == type)
    			return loadedResources[item];
    	}

    	return null;
    }


    /// <summary>Возвращает все загруженные ресурсы определенного типа</summary>
    /// <param name="type">Тип ресурса</param>
    /// <returns>Список ресурсов определенного типа<IResource></returns>
    public List<IResource> GetResource(ResourceType type)
    {
    	List<IResource> resources = new List<IResource>();

    	foreach (var item in loadedResources.Keys)
    	{
    		if (loadedResources[item].GetResType() == type)
    			resources.Add(loadedResources[item]);
    	}

    	return resources;
    }
}
