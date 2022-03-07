using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Linq;

public class StatisticFactory
{
    /// <summary>
    /// Получение всех объектов статистики
    /// </summary>
    /// <returns>Список объектов, реализующий итерфейс статистики</returns>
    public static List<StatisticData> GetStatistics()
    {
        List<StatisticData> statistics = new List<StatisticData>();
        foreach (var item in GetTypes())
        {
            var type = Type.GetType(item);
            StatisticData objToAdd = Activator.CreateInstance(type) as StatisticData;
            if (objToAdd != null)
                statistics.Add(objToAdd);
        }

        return statistics;
    }

    private static IEnumerable<string> GetTypes()
    {
        XDocument doc = XDocument.Load(System.IO.Path.Combine(Application.streamingAssetsPath, "stat.xml"));

        XElement root = doc.Element("StatObj");

        foreach (var item in root.Elements("type"))
        {
            yield return item.Value;
        }
    }
}
