using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;


public class MenuController : MonoBehaviour, ISetUpObj
{
	[SerializeField] Canvas gameOverCanvas;
	[SerializeField] Canvas victoryCanvas;

	[Header("Victory canvas")]
	[SerializeField] Text moneyTextVictory, expTextVictory;

	[Header("Game over canvas")]
	[SerializeField] Text moneyTextFailed, expTextFailed;


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
        foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<IResetObj>().ToList())
        {
			item.ResetObj();
        }
    }

	public void Replay()
	{
		Time.timeScale = 1;
    	SceneManager.LoadScene("MainMenu");
        foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<IResetObj>().ToList())
        {
			item.ResetObj();
        }
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

		SetAwardTexts();
	}


	void Victory()
	{
		foreach (var item in FindObjectsOfType<MonoBehaviour>().OfType<IResetObj>().ToArray())
			item.ResetObj();

		victoryCanvas.enabled = true;
		Time.timeScale = 0;

		SetAwardTexts();
	}

	void SetAwardTexts()
	{
		moneyTextVictory.text = moneyTextFailed.text = AwardController.GetMoneyAward().ToString();
		expTextVictory.text = expTextFailed.text = AwardController.GetExpAward().ToString();
	}

}
