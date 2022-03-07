using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveLoad : MonoBehaviour
{
    static bool isLoaded = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (!isLoaded)
        {
            SaveAndLoad.LoadGame();
            isLoaded = true;
        }
    }


    private void OnApplicationQuit()
    {
        SaveAndLoad.SaveGame();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            SaveAndLoad.SaveGame();
    }

}
