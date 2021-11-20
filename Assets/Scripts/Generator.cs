using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Generator : MonoBehaviour
{
    public List<string> types;              // Типы объектов
    public GameObject[] objects;            // Объекты
    public GameObject roomRoot;             // "Корень комнаты"
    public PlayerLogic _playerPrefab;       // Префаб игрока
    public GameObject _enemyPrefab;         // Префаб врага

    public int countOfScene;


    Map map;
    

    // TODO не забыть удалить
    private void Start()
    {
        int sceneIndex = Random.Range(0, countOfScene);
        map = XMLParser.GetMap(Application.streamingAssetsPath + $"/Scene{sceneIndex}.xml");

        GenerateRoom();
        SpawnPlayer();
        for (int i = 0; i < 5; i++)
        {
            SpawnEnemy();
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
                Instantiate(objToInstance, roomRoot.transform).transform.localPosition = pos;
            }
        }
    }


    /// <summary>
    /// Создаёт игрока на свободной клетке в первом ряду
    /// </summary>
    public void SpawnPlayer()
    {
       
    }


    public void SpawnEnemy()
    {
        
    }


    
}
