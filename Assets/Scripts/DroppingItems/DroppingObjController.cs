using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObjController : MonoBehaviour, ISetUpObj, IObserver
{
    [Header("Префабы дропа")]
	[SerializeField] DroppingObj[] drop;

    [Header("Префабы улик")]
    [SerializeField] ClueItem[] clues;

    static List<int> spawnLvl = new List<int>();              // Уровни на которых будут спавниться улики

    int enemyID;                                              // ID врага, с которого выпадет улика

	List<DroppingObj> dropInScene = new List<DroppingObj>();  // Текущий дроп на сцене
	Subject subject;

    public void SetUp() {
    	subject = FindObjectOfType<Subject>();
    	subject.AddObserver(this);


        // Выбираем на каких уровнях будут спавниться улики
        if (spawnLvl.Count == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                int lvl = Random.Range(0, 4);
                while (spawnLvl.Contains(lvl))
                    lvl = Random.Range(0, 4);
                spawnLvl.Add(lvl);
            }
        }

        // Если мы находимся на уровне, на котором нужно спавнить улику,
        // выбираем врага, с которого она выпадет
        if (spawnLvl.Contains(GameController.lvlNumber))
        {
            EnemyController[] enemies = FindObjectsOfType<EnemyController>();
            enemyID = enemies[Random.Range(0, enemies.Length)].id;
        }
        else
            enemyID = -1;
    }

    public void OnNotify(GameObject obj, EventList eventValue) {

    	// Обрабатываем смерть противника
    	if (eventValue == EventList.ENEMY_DIED) 
        {
            DroppingObj objToSpawn = null;

            var enemy = obj.GetComponent<EnemyController>();
            if (enemy != null)
            {
                // Если у умершего врага id совпадает с выбранным
                // спавним улику
                if (enemy.id == enemyID)
                    objToSpawn = Instantiate(clues[Random.Range(0, clues.Length)]);

                else
                    objToSpawn = Instantiate(drop[Random.Range(0, drop.Length)]);
            

                var spawnPos = new Vector3(obj.transform.localPosition.x, objToSpawn.transform.localPosition.y, obj.transform.localPosition.z);
                objToSpawn.transform.localPosition = spawnPos;
                dropInScene.Add(objToSpawn);
            }

    		// Проверяем количество оставшихся врагов
    		if (EnemyController.enemyCount <= 0) {
    			subject.Notify(this.gameObject, EventList.NO_ENEMIES);
    			return;
    		}
    	}

    	if (eventValue == EventList.NO_ENEMIES) {
    		Debug.Log("No enemies in scene. Move drop to player");
    		foreach (var item in dropInScene) {
    			item.Init();
    			item.StartMove();
    		}
    	}
    }
}
