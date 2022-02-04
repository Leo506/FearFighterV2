using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, ISetUpObj, IGetDamaged, IResetObj
{
    PlayerMovement movement;
    BoxCollider box;
    AttackComponent attack;
    IUsingObj currentUsingObj;
    
    [SerializeField] Animator animator;
    [SerializeField] float distanceCoeff = 1;
    [SerializeField] UnityEngine.UI.Text text;  // TODO не забыть удалить
    [SerializeField] LayerMask attackLayer;
    [SerializeField] PlayerUI ui;

    public static PlayerLogic instance;
    public static event System.Action PlayerDiedEvent;
    public float maxHP = 100;

    static float attackValue = 10;
    static float currentHP = -1;

    // Свойство для доступа и ограниченного изменения текущего здоровья
    public float CurrentHP
    {
        get
        {
            return currentHP;
        }

        set
        {
            currentHP = value;
            currentHP = Mathf.Clamp(currentHP, 0, maxHP);
            ui.ShowCurrentHp(currentHP);
        }
    }


    // Свойство для доступа к значению атаки
    public float AttackValue
    {
        get
        {
            return attackValue;
        }

        set
        {
            attackValue = value;
        }
    }


    private void Awake() 
    {
        if (instance != this && instance != null)
            Destroy(instance.gameObject);

        instance = this;    
    }


    private void Update()
    {
        text.text = transform.position.ToString();
        foreach (var item in Physics.OverlapSphere(this.transform.position, 0.5f))
        {
            DroppingObj obj = item.GetComponent<DroppingObj>();
            if (obj != null)
                obj.StartMove(this.transform);
        }
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

        ui.ShowCurrentHp(currentHP);
        
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
        FindObjectOfType<CameraController>().ChangeView();
    }


    /// <summary>
    /// Использование предмета 
    /// </summary>
    public void Use()
    {
        if (currentUsingObj != null)
        {
            currentUsingObj.Use();
            ui.ChangePlayerController();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var exit = collision.collider.GetComponent<Exit>();

        if (exit != null)
        {
            exit.GoNextLvl();
        }
            
    }

    private void OnTriggerEnter(Collider other) 
    {
        IUsingObj obj = other.GetComponent<IUsingObj>();
        if (obj != null)
        {
            ui.ChangePlayerController();
            currentUsingObj = obj;    
        }
    }


    private void OnTriggerExit(Collider other)
    {
        IUsingObj obj = other.GetComponent<IUsingObj>();
        if (obj != null)
        {
            ui.ChangePlayerController();
            currentUsingObj = null;
        }
    }


    void OnDrawGizmos()
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
     }

    public void GetDamage(float value) 
    {
    	currentHP -= value;
    	ui.ShowCurrentHp(currentHP);
    	if (currentHP <= 0) 
    	{
    		PlayerDiedEvent?.Invoke();
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
