using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BossFightPhase2
{
	public class Boss : EnemyController, ISetUpObj, IGetDamaged
	{
		[Header("Слайдер для отображения хп")]
		[SerializeField] UnityEngine.UI.Slider hpSlider;

		public static event System.Action BossDiedEvent;


	    public void SetUp() 
	    {
	    	hp = 100;
	    	hpSlider.maxValue = 100;
	    	hpSlider.value = hp;

	    	base.SetUp();

	        getDamageEffect.transform.localScale = new Vector3(1, 1, 1);

	    }


	    public override void GetDamage(float value) 
	    {
	        if (hp - value <= 0)
	            BossDiedEvent?.Invoke();

	        hpSlider.value = hp - value;

			base.GetDamage(value);
	    }
	}
}