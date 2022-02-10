using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapLoader : MonoBehaviour
{
    public string assetName = "Map0";
    public string bundleName = "StreamingAssets";

    public void Start()
    {
        AssetBundle localBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));

        if (localBundle == null)
        {
            Debug.LogError("Failed to load asset bundle");
            return;
        }

        GameObject asset = localBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);
        localBundle.Unload(false);
    }
}
