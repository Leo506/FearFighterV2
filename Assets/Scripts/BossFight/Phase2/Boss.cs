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


		private void Update()
	    {
	        if (movement != null)
	        {
	            movement.Move();

	            if (movement.GetDistanceToTarget() <= attackRadius)
	            {
	                if (canAttack)
	                    Attack();
	            }
	        }
	    }


	    public void SetUp() 
	    {
	    	hp = 100;
	    	hpSlider.maxValue = 100;
	    	hpSlider.value = hp;

	    	player = FindObjectOfType<PlayerLogic>();

        	movement = new AIMovementComponent(GetComponent<NavMeshAgent>(), player.transform);

	        box = GetComponent<BoxCollider>();
	        attack = new AttackComponent(box, transform, attackLayer);

	        getDamageEffect.transform.localScale = new Vector3(1, 1, 1);

	    }


	    public void GetDamage(float value) 
	    {
	    	hp -= value;
	    	hpSlider.value = hp;
	        Debug.Log("Get damage by " + value + " points");
	        if (hp <= 0)
	        {

	            enemyCount--;
	            Subject.instance.Notify(EventList.NO_ENEMIES);
	            Subject.instance.Notify(EventList.VICTORY);
	            Destroy(this.gameObject);
	            return;
	        }

	        Instantiate(getDamageEffect, this.transform);

	        movement.PushFromTarget();
	    }


	    protected override void Attack() 
	    {
	    	base.Attack();
	    }
	}
}