using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DroppingObjController : MonoBehaviour, ISetUpObj, IObserver
{
    [Header("Префабы обычного дропа")]
	[SerializeField] DroppingObj[] commonDrop;         // Префабы обычного дропа


    [Header("Префабы улик")]
    [SerializeField] ClueItem[] clues;                 // Префабы улик

    static int countOfClues = 0;                       // Текущее количество улик              

	Subject subject;

    public void SetUp() {
    	subject = FindObjectOfType<Subject>();
    	subject.AddObserver(this);


        // Находим точки для спавна обычного дропа
        // и спавним в них случайные предметы обычного дропа
        var dropPoints = FindObjectsOfType<MapObject>().Where(obj => obj.type == "DropPoint").ToArray();
        Debug.Log("Drop points number: " + dropPoints.Count());
        foreach (var point in dropPoints)
        {
            var obj = Instantiate(commonDrop[Random.Range(0, commonDrop.Length)]).transform.position = point.transform.position;
        }
    }

    public void OnNotify(EventList eventValue) 
    {
        // Если уровень был зачистен
        // И количество собранных улик меньше 3
        // Спавним улику в нужном месте
    	if (eventValue == EventList.NO_ENEMIES) 
        {
    		if (countOfClues < 3)
            {
                var points = FindObjectsOfType<MapObject>().Where( mapObj => mapObj.type == "CluePoint").ToArray();
                if (points.Count() != 0)
                {
                    Vector3 pos = points[0].transform.position;
                    Instantiate(clues[0]).transform.position = pos;
                }
            }
    	}
    }
}
