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

    [Header("Точка спавна эффекта удара")]
    [SerializeField] GameObject boomObj;

    [Header("Точки маршрута")]
    [SerializeField] Transform[] path;

    [Header("Индикатор обнаружения врага")]
    [SerializeField] Indicator indicator;

    protected PlayerLogic player;
    protected AIMovementComponent movement;
    protected AttackComponent attack;

    protected BoxCollider2D box;

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
            //movement.Move();

            if (canAttack)
                Attack();
        }
    }

    


    protected virtual void Attack()
    {
        
        Vector2 dirToPlayer = (player.transform.position - this.transform.position).normalized;
        viewDirection dir = movement.DetermineView(dirToPlayer);
        
        Vector2 rayDir;
        float distance;

        float scale = box.size.x * (transform.localScale.x / 2);

        switch (dir)
        {
            case viewDirection.UP:
                rayDir = Vector2.up + new Vector2(0, scale);
                distance = box.size.y;
                break;
            case viewDirection.DOWN:
                rayDir = Vector2.down + new Vector2(0, -scale);
                distance = box.size.y;
                break;
            case viewDirection.RIGHT:
                rayDir = Vector2.right + new Vector2(scale, 0);
                distance = box.size.x;
                break;
            case viewDirection.LEFT:
                rayDir = Vector2.left + new Vector2(-scale, 0);
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
        movement = new AIMovementComponent(GetComponent<NavMeshAgent>(), targets, player.transform, indicator);

        box = GetComponent<BoxCollider2D>();
        //attack = new AttackComponent(box, transform, attackLayer);

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

        //movement.PushFromTarget();

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
        Gizmos.color = Color.red;

        Vector2 rayDir;
        float distance;

        float scale = box.size.x * (transform.localScale.x / 2);

        Vector2 dirToPlayer = (player.transform.position - this.transform.position).normalized;
        viewDirection dir = movement.DetermineView(dirToPlayer);

        switch (dir)
        {
            case viewDirection.UP:
                rayDir = Vector2.up + new Vector2(0, scale);
                distance = box.size.y;
                break;
            case viewDirection.DOWN:
                rayDir = Vector2.down + new Vector2(0, -scale);
                distance = box.size.y;
                break;
            case viewDirection.RIGHT:
                rayDir = Vector2.right + new Vector2(scale, 0);
                distance = box.size.x;
                break;
            case viewDirection.LEFT:
                rayDir = Vector2.left + new Vector2(-scale, 0);
                distance = box.size.x;
                break;
            default:
                rayDir = Vector3.zero;
                distance = box.size.x;
                break;
        }
         //Gizmos.DrawRay(transform.position, rayDir * (distance - 0.03f));
         //Draw a cube at the maximum distance
         var size = box.size * transform.localScale.x;
         Gizmos.DrawWireCube((Vector2)transform.position + rayDir, size);
    }

    protected void Die()
    {
        EnemyDiedEvent?.Invoke();
    }
    
}
