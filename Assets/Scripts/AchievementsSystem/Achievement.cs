using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public struct Achievement
{
	/// <summary>
	/// Значение тукущего прогресса достижения
	/// </summary>
	public float currentProgress { get; private set; }                // Значение текущего прогресса (от 0 до 1)


	/// <summary>
	/// Id достижения
	/// </summary>
	/// <value></value>
	public int id { get; private set; }                               // Id достижения


	/// <summary>
	/// Событие получение события
	/// </summary>
	public static event Action<Achievement> AchievementGotEvent; 

	public bool IsGot { get { return currentProgress == 1; } }        // Полученно ли достижение?

	private Func<float> progressFunction;                             // Функция, возвращающая текущий прогресс по достижению

	private int awardAmount;                                          // Величина награды
	private bool awardGot;                                            // Получена ли награда


	/// <summary>
	/// Создаёт экземпляр структуры Achievement
	/// </summary>
	/// <param name="progress">Функция, определяющая прогресс по достижению</param>
	/// <param name="id">Id достижения</param>
	/// <param name="award">Величина награды</param>
	public Achievement(Func<float> progress, int id, int award)
	{
		progressFunction = progress;
		currentProgress = progressFunction();
		this.id = id;
		awardAmount = award;
		awardGot = false;
	}


	/// <summary>
	/// Получение награды
	/// </summary>
	public void GetAward()
	{
		if (!awardGot)
			Debug.Log("Получена награда");
		else
			Debug.Log("Награда была получена ранее");
	}
}
