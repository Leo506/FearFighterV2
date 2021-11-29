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
            if (enemies.Count != 0)
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
