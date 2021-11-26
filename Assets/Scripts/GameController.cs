using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IObserver
{
    [SerializeField] Subject subject;
    Queue<EnemyController> enemies = new Queue<EnemyController>();

    private void Start()
    {
        subject.AddObserver(this);
    }


    public void OnNotify(GameObject obj, EventList eventValue)
    {
        if (eventValue == EventList.ENEMY_DIED)
        {
            if (EnemyController.enemyCount <= 0)
            {
                foreach (var item in FindObjectsOfType<DroppingObj>())
                {
                    item.Init();
                    item.StartMove();
                }

                Debug.Log("Старт движения выпавших вещей");
                return;
            }

            enemies.Dequeue().MyQueue();
        }

        if (eventValue == EventList.GAME_READY_TO_START)
        {
            foreach (var item in FindObjectsOfType<EnemyController>())
            {
                enemies.Enqueue(item);
            }

            enemies.Dequeue().MyQueue();
        }
    }
}
