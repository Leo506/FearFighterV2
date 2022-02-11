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
    public ParticleSystem getDamageEffect;

    [SerializeField] GameObject boomObj;

    [SerializeField] Transform[] path;

    protected PlayerLogic player;
    protected AIMovementComponent movement;
    protected AttackComponent attack;

    protected BoxCollider box;

    protected bool canAttack = true;

    public int id { get; protected set; }
    public float delayTime  = 1.5f;

    public static event System.Action EnemyDiedEvent;
    public static int enemyCount = 0;
    public static List<EnemyController> enemiesOnScene;


    private void Update()
    {
        if (movement != null)
        {
            movement.Move();

            if (movement.GetDistanceToTarget() <= attackRadius)
            {
                if (canAttack && movement.canMove)
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

        Vector3[] targets = new Vector3[path.Length];
        for (int i = 0; i < path.Length; i++)
        {
            targets[i] = path[i].position;
        }
        movement = new AIMovementComponent(GetComponent<NavMeshAgent>(), targets, player.transform);

        box = GetComponent<BoxCollider>();
        attack = new AttackComponent(box, transform, attackLayer);

        GameController.Pause += () => movement.canMove = canAttack = false;
        GameController.Unpause += () => movement.canMove = canAttack = true;
        Exit.OnNextLvlEvent += () => enemyCount = 0;
        Exit.OnNextLvlEvent += () => enemiesOnScene?.Clear();

        if (enemiesOnScene == null)
            enemiesOnScene = new List<EnemyController>();
        enemiesOnScene.Add(this);

    }


    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    protected void OnDestroy()
    {
        GameController.Pause -= () => movement.canMove = canAttack = false;
        GameController.Unpause -= () => movement.canMove = canAttack = true;
        Exit.OnNextLvlEvent -= () => enemyCount = 0;
        Exit.OnNextLvlEvent -= () => enemiesOnScene?.Clear();
    }


    public bool IsAngry()
    {
        return movement.currentState == MovementState.FOLLOW_PLAYER;
    }



    public virtual void GetDamage(float value)
    {
        hp -= value;

        var boom = Instantiate(getDamageEffect, boomObj.transform);

        movement.PushFromTarget();

        if (hp <= 0)
        {
            
            enemyCount--;
            Debug.Log("ENEMY DIED. Enemy on scene: " + enemyCount);
            EnemyDiedEvent?.Invoke();
            GetComponent<HaveDropComponent>()?.Drop();
            enemiesOnScene.Remove(this);
            Destroy(this.gameObject);
            return;
        }
    }

    public void StopMovement(bool stop)
    {
        movement.canMove = stop;
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

    protected void Die()
    {
        EnemyDiedEvent?.Invoke();
    }
    
}
