using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class MenuController : MonoBehaviour, IObserver, ISetUpObj
{
	[SerializeField] Canvas gameOverCanvas;
	[SerializeField] Canvas victoryCanvas;
	[SerializeField] Subject subject;


	public void SetUp() 
	{
		subject.AddObserver(this);
	}


    public void Play() 
    {
    	Time.timeScale = 1;
    	SceneManager.LoadScene("LoadingScene");
    	// TODO Ресет инвенторя, характеристик персонажа и тд
    }


    public void Quit() 
    {
    	Application.Quit();
    }


    public void OnNotify(GameObject obj, EventList eventValue) 
    {
    	if (eventValue == EventList.GAME_OVER) 
    	{
    		foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<IResetObj>().ToArray())
    			item.ResetObj();

    		gameOverCanvas.enabled = true;
    		Time.timeScale = 0;
    	}


    	if (eventValue == EventList.VICTORY) 
    	{
    		foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<IResetObj>().ToArray())
    			item.ResetObj();

    		victoryCanvas.enabled = true;
    		Time.timeScale = 0;
    	}
    }

}
