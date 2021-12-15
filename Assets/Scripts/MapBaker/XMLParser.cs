using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.Networking;
using System.Globalization;


public class XMLParser: MonoBehaviour
{
    [SerializeField] Subject subject;



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


    public static PhraseResource PhraseHandler(string xml)
    {
        //xml = RemovePreambleByte(xml);

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);

        XmlElement text = doc.DocumentElement;
        PhraseResource phrase = new PhraseResource();

        if (text != null)
        {
            foreach (XmlElement txt in text)
            {
                var txtID = txt.Attributes.GetNamedItem("id").Value;
                var txtValue = txt.InnerText;

                Debug.Log("id: " + txtID + " value: " + txtValue);

                phrase.text.Add(txtID, txtValue);
            }
        }

        return phrase;
    }

    public static SceneResource MapHandler(string xml)
    {
        xml = RemovePreambleByte(xml);

        XmlDocument sceneDoc = new XmlDocument();
        sceneDoc.LoadXml(xml);

        XmlElement map = sceneDoc.DocumentElement;                                                 // Доступ к корневому элементу
        Dictionary<string, List<Vector3>> objects = new Dictionary<string, List<Vector3>>();
        List<Vector3> positions;
        string type;

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

            return new SceneResource(objects);
    }


    static string RemovePreambleByte(string str)
    {
        string _byteOrderMarkUtf8 = System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetPreamble());
        if (str.StartsWith(_byteOrderMarkUtf8))
        {
            str = str.Remove(0, _byteOrderMarkUtf8.Length);
        }

        return str;
    }
}
