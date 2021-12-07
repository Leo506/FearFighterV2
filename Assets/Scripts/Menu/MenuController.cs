using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour, IObserver, ISetUpObj
{
	[SerializeField] Canvas gameOverCanvas;
	[SerializeField] Subject subject;


	public void SetUp() 
	{
		subject.AddObserver(this);
	}


    public void Play() 
    {
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
    		gameOverCanvas.enabled = true;
    		Time.timeScale = 0;
    	}
    }

}
