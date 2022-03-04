using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController
{
	static int money = 0;  // Кол-во монет у игрока

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

		private set
		{
			if (value >= 0)
				money = value;
		}
	}
}
