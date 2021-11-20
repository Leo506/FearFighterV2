using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapBaker))]
public class MapBakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MapBaker map = this.target as MapBaker;

        if (GUILayout.Button("Bake"))
            map.Bake();
    }
}
