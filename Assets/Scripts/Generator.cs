using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Generator : MonoBehaviour
{
    public List<string> types;              // Типы объектов
    public GameObject[] objects;            // Объекты
    public GameObject roomRoot;             // "Корень комнаты"
    public PlayerLogic _playerPrefab;       // Префаб игрока
    public GameObject _enemyPrefab;         // Префаб врага

    public int countOfScene;

    NavMeshSurface surface;

    Map map;
    

    // TODO не забыть удалить
    private void Start()
    {
        int sceneIndex = Random.Range(0, countOfScene);
        map = XMLParser.GetMap(Application.streamingAssetsPath + $"/Scene{sceneIndex}.xml");

        GenerateRoom();

        surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();

        StartCoroutine(WaitBeforeSetUp());
        
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
    }
    
}
