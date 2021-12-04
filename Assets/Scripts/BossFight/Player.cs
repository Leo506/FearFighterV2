using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossFight {
	public class Player : MonoBehaviour
	{
	    [SerializeField] UnityEngine.UI.Slider playerSlider;  // Слайдер, отображающий текущее количество здоровья игрока

	    float hp = 100;
	    public bool isDead { get; private set; }

	    void Start() {
	    	playerSlider.maxValue = hp;
	    	playerSlider.value = hp;
	    	isDead = false;
	    }


	    /// <summary>Получение урона игроком</summary>
	    /// <param name="value">Количество урона</param>
	    public void GetDamage(float value) {
	    	hp -= value;
	    	playerSlider.value = hp;

	    	if (hp <= 0)
	    		isDead = true;
	    }
	}
}
