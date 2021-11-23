using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IObserver
{
    [SerializeField] Subject subject;

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
                    item.StartMove();
                }

                Debug.Log("Старт движения выпавших вещей");
            }
        }
    }
}
