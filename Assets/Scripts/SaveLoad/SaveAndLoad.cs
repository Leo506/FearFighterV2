using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoad
{
    /// <summary>
    /// Сохраняет игру
    /// </summary>
    public static void SaveGame()
    {
        GameData data = new GameData();

        using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, "gameData.FF")))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, data);
        }
    }


    /// <summary>
    /// Загружает данные игрока из файла сохранения
    /// </summary>
    /// <returns>Объект GameData с информацией игрока</returns>
    public static GameData LoadGame()
    {
        var path = Path.Combine(Application.persistentDataPath, "gameData.FF");

        if (!File.Exists(path))
            return null;

        GameData data = null;

        using (FileStream fs = File.Open(path, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            data = formatter.Deserialize(fs) as GameData;
        }

        return data;
    }
}
