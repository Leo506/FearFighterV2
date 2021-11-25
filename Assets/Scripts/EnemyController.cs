using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyController : MonoBehaviour, IGetDamaged, ISetUpObj
{
    [SerializeField] DroppingObj coin;
    [SerializeField] float hp = 100;
    [SerializeField] float attackRadius = 0.5f;

    PlayerLogic player;
    AIMovementComponent movement;
    Subject subject;

    bool canAttack = true;

    public static int enemyCount = 0;

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

    void Attack()
    {
        RaycastHit hit;
        Vector3 rayDir;

        canAttack = false;

        Vector3 dirToPlayer = (player.transform.position - this.transform.position).normalized;
        viewDirection dir = movement.currentView;

        switch (dir)
        {
            case viewDirection.TOWARD:
                rayDir = Vector3.forward;
                break;
            case viewDirection.DOWN:
                rayDir = Vector3.back;
                break;
            case viewDirection.RIGHT:
                rayDir = Vector3.right;
                break;
            case viewDirection.LEFT:
                rayDir = Vector3.left;
                break;
            default:
                rayDir = Vector3.zero;
                break;
        }

        if (Physics.Raycast(this.transform.position, rayDir, out hit, attackRadius))
        {
            Debug.Log("Enemy attack: " + hit.collider.name);
        }
        Debug.DrawLine(this.transform.position, this.transform.position + rayDir * attackRadius, Color.red);
        Invoke("Reload", 3);
    }


    void Reload()
    {
        canAttack = true;
    }


    public void SetUp()
    {
        player = FindObjectOfType<PlayerLogic>();
        subject = FindObjectOfType<Subject>();
        enemyCount++;
        movement = new AIMovementComponent(GetComponent<NavMeshAgent>(), player.transform);
    }



    public void GetDamage(float value)
    {
        hp -= value;
        Debug.Log("Get damage by " + value + " points");
        if (hp <= 0)
        {
            if (coin != null)
            {
                var obj = Instantiate(coin);
                obj.transform.position = new Vector3(this.transform.position.x, obj.transform.position.y, this.transform.position.z);
                obj.Init();
            }

            enemyCount--;
            subject.Notify(this.gameObject, EventList.ENEMY_DIED);
            Destroy(this.gameObject);
        }

        movement.PushFromTarget();
    }


    public void MyQueue()
    {
        movement.GetAgent().stoppingDistance /= 3;
    }
    
}
