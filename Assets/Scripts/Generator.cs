using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public enum TypeOfScene 
{
    BOSS_ARENA,
    SIMPLE_SCENE
}

public class Generator : MonoBehaviour
{
    public List<string> types;              // Типы объектов
    public GameObject[] objects;            // Объекты
    public GameObject roomRoot;             // "Корень комнаты"
    public PlayerLogic _playerPrefab;       // Префаб игрока
    public GameObject _enemyPrefab;         // Префаб врага
    public TypeOfScene sceneType;           // Тип генерируемой сцены

    public int countOfScene;                // Количество сцен

    [SerializeField] Subject subject;

    [SerializeField] NavMeshSurface surface;

    [SerializeField] ResourceManager manager;


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

        StartCoroutine(GenerateRoom(path));


    }




    /// <summary>
    /// Создаёт комнату
    /// </summary>
    IEnumerator GenerateRoom(string path)
    {
        ResourceManager man = new ResourceManager();
        yield return man.LoadResource(ResourceType.SCENE_RES, path);

        SceneResource scene = man.GetResource(ResourceType.SCENE_RES)[0] as SceneResource;

        foreach (string type in scene.GetTypes())
        {
            var objToInstance = objects[types.IndexOf(type)];
            foreach (Vector3 pos in scene.GetPositions(type))
            {
                var obj = Instantiate(objToInstance, roomRoot.transform);
                obj.transform.localPosition = pos;
                yield return null;
            }
        }

        surface.BuildNavMesh();
        subject.Notify(this.gameObject, EventList.GAME_READY_TO_START);
    }
    
}
