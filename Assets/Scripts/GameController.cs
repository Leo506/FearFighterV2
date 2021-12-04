using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour, IObserver
{
    [SerializeField] Subject subject;
    Queue<EnemyController> enemies = new Queue<EnemyController>();

    static int lvlNumber = 0;

    private void Start()
    {
        subject.AddObserver(this);

        foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<ISetUpObj>().ToArray())
        {
            Debug.Log("Set up!!!");
            item.SetUp();
        }

        foreach (var item in FindObjectsOfType<EnemyController>())
        {
            enemies.Enqueue(item);
        }

        enemies.Dequeue().MyQueue();
    }


    public void OnNotify(GameObject obj, EventList eventValue)
    {
        if (eventValue == EventList.ENEMY_DIED)
        {
            if (enemies.Count != 0)
                enemies.Dequeue().MyQueue();
        }

        if (eventValue == EventList.NEXT_LVL)
        {
            lvlNumber++;
            if (lvlNumber == 4)
                SceneManager.LoadScene("Dialog");
            else
                SceneManager.LoadScene("LoadingScene");
        }
    }
}
