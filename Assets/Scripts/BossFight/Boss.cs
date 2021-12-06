using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossFight
{
	public class Boss : MonoBehaviour
	{
		[SerializeField] UIController uiController;  // Объект, контролирующий вывод текста на экран
		[SerializeField] Player player;

	    int requireClueId = 0;                       // Улику с каким ID требуется сейчас использовать
	    
	    public static float hp = 100;                // Кол-во очков здоровья у босса

	    void Start() {
	    	uiController.RegisterNextID("_StartDialog");
	    }


	    /// <summary>Пытаемся атаковать босса (т.е перетаскиваем нужную улику)</summary>
	    /// <param name="id">id улики</param>
	    public bool TryAttack(int id) {

	    	// Если id улики совпадает с требуемым id,
	    	// то босс получает урон
	    	if (requireClueId == id) {

	    		hp -= PlayerLogic.attackValue;
	    		requireClueId++;

	    		if (hp <= 0) 
	    		{
	    			uiController.RegisterNextID("_EndDialog");
	    			return true;
	    		}

	    		uiController.StopShow();
	    		uiController.RegisterNextID($"_Clue{requireClueId}");
	    		uiController.StartShow();

	    		if (requireClueId >= 3 && hp != 0) 
	    		{
	    			uiController.RegisterNextID("_SecondPhase");
	    			uiController.canLoad2Phase = true;
	    			return true;
	    		}

	    		return true;
	    	} 

	    	// Игрок выбрал неправильную улику
	    	else {
	    		player.GetDamage(35);

	    		if (player.isDead)
	    			uiController.RegisterNextID("_Victory");
	    		else
	    			uiController.RegisterNextID("_UncorrectClue");

	    		return false;
	    	}
	    }
	}
}