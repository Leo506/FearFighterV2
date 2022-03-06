using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    private List<ISaveable> objToSave;

    public GameData()
    {
        objToSave = SaveFactory.GetSaveableObjects();
    }

    public void Load()
    {
        foreach (var item in objToSave)
        {
            item.Load();
        }
    }
}
