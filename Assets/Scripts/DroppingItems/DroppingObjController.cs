using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DroppingObjController : MonoBehaviour, ISetUpObj, IResetObj
{
    [Header("Префабы обычного дропа")]
	[SerializeField] DroppingObj[] commonDrop;         // Префабы обычного дропа


    [Header("Префабы улик")]
    [SerializeField] ClueItem[] clues;                 // Префабы улик

    [Header("Префабы дропа с врагов")]
    [SerializeField] DroppingObj[] enemydrop;

    public static int countOfClues = 0;                       // Текущее количество улик


    public void SetUp() 
    {
        GameController.NoEnemiesEvent += OnNoEnemies;

        SetHaveDropEnemies();


        // Находим точки для спавна обычного дропа
        // и спавним в них случайные предметы обычного дропа
        var dropPoints = FindObjectsOfType<MapObject>().Where(obj => obj.type == "DropPoint").ToArray();
        Debug.Log("Drop points number: " + dropPoints.Count());
        foreach (var point in dropPoints)
        {
            var obj = Instantiate(commonDrop[Random.Range(0, commonDrop.Length)]).transform.position = point.transform.position;
        }
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        GameController.NoEnemiesEvent -= OnNoEnemies;
    }


    public void ResetObj()
    {
        countOfClues = 0;
    }

    public void OnNoEnemies() 
    {
        // Если уровень был зачистен
        // И количество собранных улик меньше 3
        // Спавним улику в нужном месте
        if (countOfClues < 3)
        {
            Debug.Log("Spawning clue...\nNumber of enemies: " + EnemyController.enemyCount);
            var points = FindObjectsOfType<MapObject>().Where( mapObj => mapObj.type == "CluePoint").ToArray();
            if (points.Count() != 0)
            {
                Vector3 pos = points[0].transform.position;
                var clue = Instantiate(clues[0]);
                clue.transform.position = pos;

                if (CameraController.instance.isReverse)
                    clue.GetComponentInChildren<SpriteRenderer>().transform.localRotation = Quaternion.Euler(45, 180, 0);
            }
        }
    }


    void SetHaveDropEnemies()
    {
        int count = Random.Range(1, EnemyController.enemyCount / 2);  // Количество врагов с дропом
        Debug.Log("Count of drop enemies: " + count);
        List<int> indexes = new List<int>();
        var enemies = FindObjectsOfType<EnemyController>();

        // Создаём список индексов врагов, с которых будет падать дроп
        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0, EnemyController.enemyCount);
            while (indexes.Contains(index))
                index = Random.Range(0, EnemyController.enemyCount);
            indexes.Add(index);
        }

        foreach (var item in indexes)
        {
            Debug.Log("Index of drop enemy: " + item);
            HaveDropComponent hdc = enemies[item].gameObject.AddComponent<HaveDropComponent>();
            hdc.SetItem(enemydrop[Random.Range(0, enemydrop.Length)]);

            // Ресайз характеристик врага
            enemies[item].gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);  // Ресайз показателя scale
            
            // Ресайз размера коллайдера
            Vector3 size = enemies[item].gameObject.GetComponent<BoxCollider>().size;
            size = new Vector3(size.x / 1.5f, size.y / 1.5f, size.z / 1.5f);
            enemies[item].gameObject.GetComponent<BoxCollider>().size = size;

            // Ресайз NavMeshAgent'а
            UnityEngine.AI.NavMeshAgent agent = enemies[item].gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.radius /= 1.5f;
            agent.height /= 1.5f;
        }
    }
}
