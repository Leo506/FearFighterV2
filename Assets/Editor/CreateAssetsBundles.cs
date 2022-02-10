using System.IO;
using UnityEditor;

public class CreateAssetsBundles
{
    [MenuItem("Assets/Create All Asset Bundles")]
    static void CreateAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/StreamingAssets/GameMaps";
        if (!Directory.Exists(assetBundleDirectory))
            Directory.CreateDirectory(assetBundleDirectory);

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
