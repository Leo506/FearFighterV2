using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class MenuController : MonoBehaviour, ISetUpObj
{
	[SerializeField] Canvas gameOverCanvas;
	[SerializeField] Canvas victoryCanvas;


	public void SetUp() 
	{
		PlayerLogic.PlayerDiedEvent += GameOver;
		BossFightPhase2.Boss.BossDiedEvent += Victory;
	}

	
	void OnDestroy()
	{
		PlayerLogic.PlayerDiedEvent -= GameOver;
		BossFightPhase2.Boss.BossDiedEvent -= Victory;
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


	void GameOver()
	{
		foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<IResetObj>().ToArray())
			item.ResetObj();

		gameOverCanvas.enabled = true;
		Time.timeScale = 0;
	}


	void Victory()
	{
		foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<IResetObj>().ToArray())
			item.ResetObj();

		victoryCanvas.enabled = true;
		Time.timeScale = 0;
	}

}
