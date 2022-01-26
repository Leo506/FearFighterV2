using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyController : MonoBehaviour, IGetDamaged, ISetUpObj
{
    [Header("Здоровье врага")]
    [SerializeField] protected float hp = 100;

    [Header("Радиус атаки")]
    [SerializeField] protected float attackRadius = 0.5f;

    [Header("Маска атаки")]
    [SerializeField] protected LayerMask attackLayer;

    [Header("Эффект получения урона")]
    [SerializeField] protected ParticleSystem getDamageEffect;

    protected PlayerLogic player;
    protected AIMovementComponent movement;
    protected AttackComponent attack;

    protected BoxCollider box;

    protected bool canAttack = true;

    public static int enemyCount = 0;
    public int id { get; protected set; }
    public float delayTime  = 1.5f;


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
        Invoke("Reload", delayTime);
    }


    protected virtual void Reload()
    {
        canAttack = true;
    }


    public void SetUp()
    {
        player = FindObjectOfType<PlayerLogic>();

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
            Subject.instance.Notify(EventList.ENEMY_DIED);
            GetComponent<HaveDropComponent>()?.Drop();
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
        Vector3 size = new Vector3(
            box.size.x * transform.localScale.x,
            box.size.y * transform.localScale.y,
            box.size.z * transform.localScale.z
            );
        Gizmos.DrawWireCube(transform.position + movement.DetermineView(movement.currentView) * box.size.z + new Vector3(0, box.center.y * transform.localScale.y, 0), size);
    }
    
}
