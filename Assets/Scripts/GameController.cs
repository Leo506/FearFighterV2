using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour, IObserver
{
    Queue<EnemyController> enemies = new Queue<EnemyController>();

    public static int lvlNumber = 0;

    private void Start()
    {
        Subject.instance.AddObserver(this);

        foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<ISetUpObj>().ToArray())
        {
            //Debug.Log("Set up!!!");
            item.SetUp();
        }

        foreach (var item in FindObjectsOfType<EnemyController>())
        {
            enemies.Enqueue(item);
        }

        enemies.Dequeue().MyQueue();
    }


    public void OnNotify(EventList eventValue)
    {
        

        if (eventValue == EventList.ENEMY_DIED)
        {
            if (enemies.Count != 0)
                enemies.Dequeue().MyQueue();
            
        // Проверяем количество оставшихся врагов
        if (EnemyController.enemyCount <= 0) {
            Subject.instance.Notify(EventList.NO_ENEMIES);
            return;
        }
        }

        if (eventValue == EventList.NEXT_LVL)
        {
            lvlNumber++;
            if (lvlNumber == 4) 
            {
            	Destroy(FindObjectOfType<Loading.Map>().gameObject);
                SceneManager.LoadScene("Dialog");
            }
            else
                SceneManager.LoadScene("LoadingScene");
        }
    }


    /// <summary>
    /// Ставит игру на паузу
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0;
    }


    /// <summary>
    /// Снимает с паузы игру
    /// </summary>
    public void Unpause()
    {
        Time.timeScale = 1;
    }
}
