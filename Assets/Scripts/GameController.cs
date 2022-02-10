using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour, IResetObj
{
    Queue<EnemyController> enemies = new Queue<EnemyController>();

    public static int lvlNumber = 2;


    // События, которые вызывает GameController
    public static event System.Action NoEnemiesEvent;
    public static event System.Action Pause;
    public static event System.Action Unpause;

    private void Start()
    {
        EnemyController.EnemyDiedEvent += OnEnemyDied;
        Exit.OnNextLvlEvent += OnNextLvl;

        foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<ISetUpObj>().ToArray())
            item.SetUp();

        foreach (var item in FindObjectsOfType<EnemyController>())
            enemies.Enqueue(item);

        enemies.Dequeue().MyQueue();
    }

    private void OnDestroy() 
    {
        EnemyController.EnemyDiedEvent -= OnEnemyDied;
        Exit.OnNextLvlEvent -= OnNextLvl;
    }


    void OnEnemyDied()
    {
        if (enemies.Count != 0)
            enemies.Dequeue().MyQueue();
        else
            NoEnemiesEvent?.Invoke();
    }


    void OnNextLvl()
    {
        lvlNumber++;
        if (lvlNumber == 4) 
        {
            Destroy(FindObjectOfType<Loading.Map>().gameObject);
            SceneManager.LoadScene("BossFightPhase2");
        }
        else
            SceneManager.LoadScene("LoadingScene");
    }


    /// <summary>
    /// Ставит игру на паузу
    /// </summary>
    public void SetPause()
    {
        Pause?.Invoke();
    }


    /// <summary>
    /// Снимает с паузы игру
    /// </summary>
    public void SetUnpause()
    {
        Unpause?.Invoke();
    }

    public void ResetObj()
    {
        lvlNumber = 2;
    }
}
