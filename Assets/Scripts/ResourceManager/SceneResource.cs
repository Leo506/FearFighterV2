using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneResource: IResource
{
    Dictionary<string, List<Vector3>> objects;                    // Словарь тип объекта:список координат таких объектов


    /// <summary>
    /// Создаёт структуру, представляющую одну комнату
    /// </summary>
    /// <param name="objs">Словарь тип объекта:список координат таких объектов</param>
    public SceneResource(Dictionary<string, List<Vector3>> objs)
    {
        this.objects = new Dictionary<string, List<Vector3>>();
        objects = objs;
    }


    /// <summary>
    /// Возвращает список типов объектов
    /// </summary>
    /// <returns></returns>
    public List<string> GetTypes()
    {
        List<string> types = new List<string>();
        foreach (var item in objects.Keys)
        {
            types.Add(item);
        }

        return types;
    }


    /// <summary>
    /// Возвращает список координат для каждого объекта определенного типа
    /// </summary>
    /// <param name="type">Тип объекта</param>
    /// <returns></returns>
    public List<Vector3> GetPositions(string type)
    {
        return objects[type];
    }


    public ResourceType GetResType()
    {
        return ResourceType.SCENE_RES;
    }
}
