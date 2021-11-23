using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBaker : MonoBehaviour
{
    public GameObject roomRoot;
    public string filePath;

    Dictionary<string, List<Vector3>> obj = new Dictionary<string, List<Vector3>>();

    public void Bake()
    {
        for (int i = 0; i < roomRoot.transform.childCount; i++)
        {
            MapObject child = roomRoot.transform.GetChild(i).GetComponent<MapObject>();
            string type = child.type;

            if (obj.ContainsKey(type))
            {
                obj[type].Add(child.transform.localPosition);
            } else
            {
                obj.Add(type, new List<Vector3>());
                obj[type].Add(child.transform.localPosition);
            }
        }

        foreach (var item in obj.Keys)
        {
            Debug.Log("Type: " + item);
        }
        XMLParser.CreateNewMap(obj, filePath);
    }
}
