using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System;

public class SaveFactory
{
    /// <summary>
    /// Получение всех объектов, которые надо сохранить
    /// </summary>
    /// <returns></returns>
    public static List<ISaveable> GetSaveableObjects()
    {
        List<ISaveable> objToSave = new List<ISaveable>();

        foreach (var item in GetTypes())
        {
            var type = Type.GetType(item);
            ISaveable objToAdd = Activator.CreateInstance(type) as ISaveable;
            objToSave.Add(objToAdd);
        }

        return objToSave;
    }


    private static IEnumerable<string> GetTypes()
    {
        XDocument doc = XDocument.Load(System.IO.Path.Combine(Application.streamingAssetsPath, "saveObjs.xml"));

        XElement root = doc.Element("SaveObjs");

        foreach (var item in root.Elements("type"))
        {
            yield return item.Value;
        }
    }
}
