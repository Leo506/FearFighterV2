using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObjController : MonoBehaviour, ISetUpObj, IObserver
{
	[SerializeField] DroppingObj[] drop;

	List<DroppingObj> dropInScene = new List<DroppingObj>();
	Subject subject;

    public void SetUp() {
    	subject = FindObjectOfType<Subject>();
    	subject.AddObserver(this);
    }

    public void OnNotify(GameObject obj, EventList eventValue) {

    	// Обрабатываем смерть противника
    	if (eventValue == EventList.ENEMY_DIED) {

    		// Объект дропа для спавна
    		var objToSpawn = Instantiate(drop[Random.Range(0, drop.Length)]);
    		var spawnPos = new Vector3(obj.transform.localPosition.x, objToSpawn.transform.localPosition.y, obj.transform.localPosition.z);
    		objToSpawn.transform.localPosition = spawnPos;
    		dropInScene.Add(objToSpawn);

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
