using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System;
using System.IO;

public class SaveFactory
{

    /// <summary>
    /// Получение всех объектов, которые надо сохранить
    /// </summary>
    /// <returns></returns>
    public static List<ISaveable> GetSaveableObjects()
    {
        List<ISaveable> objToSave = new List<ISaveable>();
        string xml;
        GetXml(out xml);
        foreach (var item in GetTypes(xml))
        {
            var type = Type.GetType(item);
            ISaveable objToAdd = Activator.CreateInstance(type) as ISaveable;
            objToSave.Add(objToAdd);
        }

        return objToSave;
    }


    private static IEnumerable<string> GetTypes(string xml)
    {
        XDocument doc = XDocument.Parse(xml);

        XElement root = doc.Element("SaveObjs");

        foreach (var item in root.Elements("type"))
        {
            yield return item.Value;
        }
    }

    private static void GetXml(out string xml)
    {
        AssetBundle asset = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "GameMaps/xml"));

        xml = asset.LoadAsset<TextAsset>("saveObjs.xml").text;

        asset.Unload(true);
    }
}
