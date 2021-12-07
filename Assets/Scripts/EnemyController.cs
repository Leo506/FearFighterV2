using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyController : MonoBehaviour, IGetDamaged, ISetUpObj
{
    [SerializeField] protected float hp = 100;
    [SerializeField] protected float attackRadius = 0.5f;
    [SerializeField] protected LayerMask attackLayer;
    [SerializeField] protected ParticleSystem getDamageEffect;

    protected PlayerLogic player;
    protected AIMovementComponent movement;
    protected AttackComponent attack;
    protected Subject subject;

    protected BoxCollider box;

    protected bool canAttack = true;

    public static int enemyCount = 0;
    public int id { get; private set; }


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


    protected virtual void Attack()
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

        attack.Attack(rayDir, distance, 10);
        Debug.Log("Attack!!!");
        Invoke("Reload", 3);
    }


    protected virtual void Reload()
    {
        canAttack = true;
    }


    public void SetUp()
    {
        player = FindObjectOfType<PlayerLogic>();
        subject = FindObjectOfType<Subject>();

        id = enemyCount;
        enemyCount++;

        movement = new AIMovementComponent(GetComponent<NavMeshAgent>(), player.transform);

        box = GetComponent<BoxCollider>();
        attack = new AttackComponent(box, transform, attackLayer);

        Debug.Log("movement component is null " + movement == null);
        Debug.Log("attack component is null " + attack == null);
    }



    public void GetDamage(float value)
    {
        hp -= value;
        Debug.Log("Get damage by " + value + " points");
        if (hp <= 0)
        {

            enemyCount--;
            subject.Notify(this.gameObject, EventList.ENEMY_DIED);
            Destroy(this.gameObject);
            return;
        }

        Instantiate(getDamageEffect, this.transform);

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
