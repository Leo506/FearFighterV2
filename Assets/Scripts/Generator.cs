using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public enum TypeOfScene 
{
    BOSS_ARENA,
    SIMPLE_SCENE
}

public class Generator : MonoBehaviour
{
    public ParticleSystem boom;
    public List<string> types;              // Типы объектов
    public GameObject[] objects;            // Объекты
    public GameObject roomRoot;             // "Корень комнаты"
    public PlayerLogic _playerPrefab;       // Префаб игрока
    public GameObject _enemyPrefab;         // Префаб врага
    public TypeOfScene sceneType;           // Тип генерируемой сцены

    public int countOfScene;                // Количество сцен


    [SerializeField] NavMeshSurface surface;

    [SerializeField] ResourceManager manager;

    public static event System.Action MapReadyEvent; 


    private void Start()
    {
        int sceneIndex = Random.Range(0, countOfScene);

        string path = "";

        switch (sceneType) 
        {
            case TypeOfScene.BOSS_ARENA:
                #if UNITY_EDITOR
                    path = "file://" + Application.streamingAssetsPath + $"/Scenes/BossArena/BA.xml";
                #else
                    path = "jar:file://" + Application.dataPath + $"!/assets/Scenes/BossArena/BA.xml";
                #endif
                break;

            case TypeOfScene.SIMPLE_SCENE:
                #if UNITY_EDITOR
                    path = "file://" + Application.streamingAssetsPath + $"/Scenes/Scene{sceneIndex}.xml";
                #else
                    path = "jar:file://" + Application.dataPath + $"!/assets/Scenes/Scene{sceneIndex}.xml";
                #endif
                break;
        }

        GenerateRoom(sceneIndex);


    }




    /// <summary>
    /// Создаёт комнату
    /// </summary>
    public void GenerateRoom(int sceneIndex)
    {

        AssetBundle localBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, $"GameMaps/maps"));

        if (localBundle == null)
        {
            Debug.LogError("Failed to load asset bundle");
            return;
        }

        GameObject asset = localBundle.LoadAsset<GameObject>($"Map{sceneIndex}");
        Instantiate(asset, roomRoot.transform);
        localBundle.Unload(false);

        surface.BuildNavMesh();
        FindObjectOfType<EnemyController>().getDamageEffect = boom;
        MapReadyEvent?.Invoke();
        //UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    
}
