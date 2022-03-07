using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Linq;
using System.IO;

public class StatisticFactory
{

    /// <summary>
    /// Получение всех объектов статистики
    /// </summary>
    /// <returns>Список объектов, реализующий итерфейс статистики</returns>
    public static List<StatisticData> GetStatistics()
    {
        List<StatisticData> statistics = new List<StatisticData>();
        string xml;
        GetXml(out xml);
        foreach (var item in GetTypes(xml))
        {
            var type = Type.GetType(item);
            StatisticData objToAdd = Activator.CreateInstance(type) as StatisticData;
            if (objToAdd != null)
                statistics.Add(objToAdd);
        }

        return statistics;
    }

    private static IEnumerable<string> GetTypes(string xml)
    {

        XDocument doc = XDocument.Parse(xml);

        XElement root = doc.Element("StatObj");

        foreach (var item in root.Elements("type"))
        {
            yield return item.Value;
        }
    }

    private static void GetXml(out string xml)
    {
        AssetBundle asset = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "GameMaps/xml"));

        xml = asset.LoadAsset<TextAsset>("stat.xml").text;

        asset.Unload(true);
    }
}
