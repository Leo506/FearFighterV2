using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController
{
	static int money = 0;  // Кол-во монет у игрока

	/// <summary>
	/// Событие вызывается, когда меняется значение денег
	/// </summary>
	public static event System.Action MoneyChanged;

	/// <summary>
	/// Количество денег у игрока
	/// </summary>
	/// <value></value>
	public static int Money
	{
		get
		{
			return money;
		}

		set
		{
			if (value >= 0)
			{
				money = value;
				MoneyChanged?.Invoke();
			}
		}
	}
}
