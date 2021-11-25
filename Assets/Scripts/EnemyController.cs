using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyController : MonoBehaviour, IGetDamaged, ISetUpObj
{
    [SerializeField] DroppingObj coin;
    [SerializeField] float hp = 100;
    [SerializeField] float attackRadius = 0.5f;
    [SerializeField] LayerMask attackLayer;

    PlayerLogic player;
    AIMovementComponent movement;
    AttackComponent attack;
    Subject subject;

    BoxCollider box;

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
        Vector3 rayDir;
        float distance;

        canAttack = false;

        Vector3 dirToPlayer = (player.transform.position - this.transform.position).normalized;
        viewDirection dir = movement.DetermineView(dirToPlayer);

        switch (dir)
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

        attack.Attack(rayDir, distance);
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

        box = GetComponent<BoxCollider>();
        attack = new AttackComponent(box, transform, attackLayer);
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

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * box.size.z);
        //Draw a cube at the maximum distance
        Gizmos.DrawWireCube(transform.position + movement.DetermineView(movement.currentView) * box.size.z, box.size);
    }
    
}
