using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class Generator : MonoBehaviour, IObserver
{
    public List<string> types;              // Типы объектов
    public GameObject[] objects;            // Объекты
    public GameObject roomRoot;             // "Корень комнаты"
    public PlayerLogic _playerPrefab;       // Префаб игрока
    public GameObject _enemyPrefab;         // Префаб врага

    public int countOfScene;

    [SerializeField] Subject subject;

    XMLParser parser;

    Map map;
    

    // TODO не забыть удалить
    private void Start()
    {
        subject.AddObserver(this);
        int sceneIndex = Random.Range(0, countOfScene);
        parser = GetComponent<XMLParser>();

#if UNITY_EDITOR
        parser.GetMap("file://" + Application.streamingAssetsPath + $"/Scene{sceneIndex}.xml");
#else
        parser.GetMap("jar:file://" + Application.dataPath + $"!/assets/Scene{sceneIndex}.xml");
#endif   
    }

    public void OnNotify(GameObject obj, EventList eventValue)
    {
        if (eventValue == EventList.MAP_READY)
        {
            map = parser.map;
            GenerateRoom();

            StartCoroutine(WaitBeforeSetUp());
        }
    }


    /// <summary>
    /// Создаёт комнату, состоящую из 25 препятствий
    /// </summary>
    public void GenerateRoom()
    {
        foreach (string type in map.GetTypes())
        {
            var objToInstance = objects[types.IndexOf(type)];
            foreach (Vector3 pos in map.GetPositions(type))
            {
                var obj = Instantiate(objToInstance, roomRoot.transform);
                obj.transform.localPosition = pos;
            }
        }
    }


    IEnumerator WaitBeforeSetUp()
    {
        yield return new WaitForSeconds(3);
        foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<ISetUpObj>().ToArray())
        {
            item.SetUp();
        }

        subject.Notify(this.gameObject, EventList.GAME_READY_TO_START);
        AstarPath.active.Scan();
    }
    
}
