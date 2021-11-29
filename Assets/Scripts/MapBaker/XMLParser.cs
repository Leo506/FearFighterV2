using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.Networking;
using System.Globalization;


public struct Map
{
    Dictionary<string, List<Vector3>> objects;                    // Словарь тип объекта:список координат таких объектов


    /// <summary>
    /// Создаёт структуру, представляющую одну комнату
    /// </summary>
    /// <param name="objs">Словарь тип объекта:список координат таких объектов</param>
    public Map(Dictionary<string, List<Vector3>> objs)
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
}

public class XMLParser: MonoBehaviour
{
    [SerializeField] Subject subject;

    public Map map;

    UnityWebRequest uwr;

    public void GetMap(string path)
    {
        StartCoroutine(GetMapFromFile(path));
    }


    public static void CreateNewMap(Dictionary<string, List<Vector3>> objects, string filePath)
    {
        if (!System.IO.File.Exists(Application.streamingAssetsPath + "/" + filePath))
        {
            using (var sf = new System.IO.StreamWriter(System.IO.File.Create(Application.streamingAssetsPath + "/" + filePath), System.Text.Encoding.UTF8))
            {
                string str1 = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
                string str2 = "<Map></Map>";

                System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();
                sf.WriteLine(str1);
                sf.WriteLine(str2);

            }
        }

        XmlDocument doc = new XmlDocument();
        doc.Load(Application.streamingAssetsPath + "/" + filePath);

        XmlElement map = doc.DocumentElement;
        foreach (var item in objects.Keys)
        {
            XmlElement obstacle = doc.CreateElement("Obstacle");
            XmlAttribute type = doc.CreateAttribute("type");
            XmlText typeText = doc.CreateTextNode(item);
            type.AppendChild(typeText);
            obstacle.Attributes.Append(type);
            map.AppendChild(obstacle);

            foreach (var pos in objects[item])
            {
                XmlElement position = doc.CreateElement("Position");
                XmlElement x = doc.CreateElement("X");
                XmlElement y = doc.CreateElement("Y");
                XmlElement z = doc.CreateElement("Z");

                XmlText xText = doc.CreateTextNode(pos.x.ToString().Replace(",", "."));
                XmlText yText = doc.CreateTextNode(pos.y.ToString().Replace(",", "."));
                XmlText zText = doc.CreateTextNode(pos.z.ToString().Replace(",", "."));

                x.AppendChild(xText);
                y.AppendChild(yText);
                z.AppendChild(zText);

                position.AppendChild(x);
                position.AppendChild(y);
                position.AppendChild(z);

                obstacle.AppendChild(position);

            }
        }

        doc.Save(Application.streamingAssetsPath + "/" + filePath);
    }

    IEnumerator GetMapFromFile(string path)
    {
        using (uwr = UnityWebRequest.Get(path))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            } else
            {
                XmlDocument sceneDoc;
                sceneDoc = new XmlDocument();
                var tmp = uwr.downloadHandler.text;
                string _byteOrderMarkUtf8 = System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetPreamble());
                if (tmp.StartsWith(_byteOrderMarkUtf8))
                {
                    tmp = tmp.Remove(0, _byteOrderMarkUtf8.Length);
                }
                sceneDoc.LoadXml(tmp);

                XmlElement map = sceneDoc.DocumentElement;                                                 // Доступ к корневому элементу
                Dictionary<string, List<Vector3>> objects = new Dictionary<string, List<Vector3>>();
                List<Vector3> positions;
                string type;

                if (map != null)
                {
                    CultureInfo ci = new CultureInfo("en-US");
                    ci.NumberFormat.NumberDecimalSeparator = ".";

                    // Проходим по всем тегам Obstacle
                    foreach (XmlElement item in map)
                    {
                        positions = new List<Vector3>();

                        // Получаем тип препятствия
                        type = item.Attributes.GetNamedItem("type").Value;

                        // Получаем координаты каждого препятствия
                        foreach (XmlNode position in item.ChildNodes)
                        {
                            float x = 0;
                            float y = 0;
                            float z = 0;

                            foreach (XmlNode coordinates in position.ChildNodes)
                            {
                                Debug.Log(coordinates.InnerText);

                                if (coordinates.Name == "X")
                                    float.TryParse(coordinates.InnerText, NumberStyles.Float, ci, out x);

                                if (coordinates.Name == "Y")
                                    float.TryParse(coordinates.InnerText, NumberStyles.Float, ci, out y);

                                if (coordinates.Name == "Z")
                                    float.TryParse(coordinates.InnerText, NumberStyles.Float, ci, out z);
                            }

                            positions.Add(new Vector3(x, y, z));
                        }

                        objects.Add(type, positions);
                    }

                }

                this.map = new Map(objects);
                subject.Notify(this.gameObject, EventList.MAP_READY);
            }
        }
    }
}
