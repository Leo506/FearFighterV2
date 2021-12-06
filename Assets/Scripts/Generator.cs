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

public class Generator : MonoBehaviour, IObserver
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

    XMLParser parser;

    Map map;
    

    // TODO не забыть удалить
    private void Start()
    {
        subject.AddObserver(this);
        int sceneIndex = Random.Range(0, countOfScene);
        parser = GetComponent<XMLParser>();

        switch (sceneType) 
        {
            case TypeOfScene.BOSS_ARENA:
                #if UNITY_EDITOR
                    parser.GetMap("file://" + Application.streamingAssetsPath + $"/Scenes/BossArena/BA.xml");
                #else
                    parser.GetMap("jar:file://" + Application.dataPath + $"!/assets/Scenes/BossArena/BA.xml");
                #endif
                break;

            case TypeOfScene.SIMPLE_SCENE:
                #if UNITY_EDITOR
                    parser.GetMap("file://" + Application.streamingAssetsPath + $"/Scenes/Scene{sceneIndex}.xml");
                #else
                    parser.GetMap("jar:file://" + Application.dataPath + $"!/assets/Scenes/Scene{sceneIndex}.xml");
                #endif
                break;
        }


    }


    public void OnNotify(GameObject obj, EventList eventValue)
    {
        if (eventValue == EventList.MAP_READY)
        {
            map = parser.map;
            StartCoroutine(GenerateRoom());

            //subject.Notify(this.gameObject, EventList.GAME_READY_TO_START);
        }
    }


    /// <summary>
    /// Создаёт комнату
    /// </summary>
    IEnumerator GenerateRoom()
    {
        foreach (string type in map.GetTypes())
        {
            var objToInstance = objects[types.IndexOf(type)];
            foreach (Vector3 pos in map.GetPositions(type))
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
