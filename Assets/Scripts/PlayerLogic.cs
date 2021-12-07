using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, ISetUpObj, IGetDamaged, IResetObj
{
    PlayerMovement movement;
    BoxCollider box;
    AttackComponent attack;
    Subject subject;
    
    [SerializeField] Animator animator;
    [SerializeField] float distanceCoeff = 1;
    [SerializeField] UnityEngine.UI.Text text;  // TODO не забыть удалить
    [SerializeField] LayerMask attackLayer;
    [SerializeField] PlayerUI ui;
    public float maxHP = 100;

    public static float attackValue = 10;
    public static float currentHP = -1;


    private void Update()
    {
        text.text = transform.position.ToString();
    }

    /// <summary>
    /// Настройка игрока
    /// </summary>
    public void SetUp()
    {
        movement = GetComponent<PlayerMovement>();
        box = GetComponent<BoxCollider>();
        attack = new AttackComponent(box, transform, attackLayer);
        FindObjectOfType<Cinemachine.CinemachineVirtualCamera>().Follow = this.transform;

        if (currentHP == -1) 
        	currentHP = maxHP;

        ui.ShowCurrentHp();
        subject = FindObjectOfType<Subject>();
    }


    /// <summary>
    /// Атака игрока
    /// </summary>
    public void Attack()
    {

        Vector3 rayDir;
        float distance;

        switch (movement.currentViewDirection)
        {
            case viewDirection.TOWARD:
                rayDir = Vector3.forward;
                distance = box.size.z;
                break;
            case viewDirection.DOWN:
                rayDir = Vector3.back;
                distance = box.size.z;
                break;
            case viewDirection.RIGHT:
                rayDir = Vector3.right;
                distance = box.size.x;
                break;
            case viewDirection.LEFT:
                rayDir = Vector3.left;
                distance = box.size.x;
                break;
            default:
                rayDir = Vector3.zero;
                distance = box.size.x;
                break;
        }

        attack.Attack(rayDir, distance, attackValue);
        animator.SetTrigger("Attack");
    }

    private void OnCollisionEnter(Collision collision)
    {
        var exit = collision.collider.GetComponent<Exit>();

        if (exit != null)
        {
            if (exit.available)
                exit.GoNextLvl();
        }
            
    }


    /* void OnDrawGizmos()
     {
         Gizmos.color = Color.red;

         Vector3 rayDir;
         float distance;

         switch (movement.currentViewDirection)
         {
             case viewDirection.TOWARD:
                 rayDir = Vector3.forward;
                 distance = box.size.z;
                 break;
             case viewDirection.DOWN:
                 rayDir = Vector3.back;
                 distance = box.size.z;
                 break;
             case viewDirection.RIGHT:
                 rayDir = Vector3.right;
                 distance = box.size.x;
                 break;
             case viewDirection.LEFT:
                 rayDir = Vector3.left;
                 distance = box.size.x;
                 break;
             default:
                 rayDir = Vector3.zero;
                 distance = box.size.x;
                 break;
         }
         Gizmos.DrawRay(transform.position, rayDir * (distance - 0.03f));
         //Draw a cube at the maximum distance
         Gizmos.DrawWireCube(transform.position + rayDir * (distance - 0.03f), box.size);
     }*/

    public void GetDamage(float value) 
    {
    	currentHP -= value;
    	ui.ShowCurrentHp();
    	if (currentHP <= 0) 
    	{
    		subject.Notify(this.gameObject, EventList.GAME_OVER);
    		Destroy(this.gameObject);
    		Debug.Log("Игрок умер");
    	}
    }


    public void ResetObj() 
    {
    	attackValue = 10;
    	currentHP = -1;
    } 
}
