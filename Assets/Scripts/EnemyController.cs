using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IGetDamaged, ISetUpObj
{
    [SerializeField] CoinController coin;
    public float hp = 100;
    public float attackRadius = 1;

    PlayerLogic player;
    NavMeshAgent agent;
    bool canAttack = true;

    viewDirection currentView = viewDirection.LEFT;

    private void Update()
    {
        if (agent != null && player != null)
        {
            agent.SetDestination(player.transform.position);

            if (Vector3.Distance(this.transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                if (canAttack)
                {
                    Attack();
                }
            }

            currentView = DetermineView(agent.velocity);
        }
    }

    void Attack()
    {
        RaycastHit hit;
        Vector3 rayDir;

        canAttack = false;

        Vector3 dirToPlayer = (player.transform.position - this.transform.position).normalized;
        viewDirection dir = DetermineView(dirToPlayer);

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


    viewDirection DetermineView(Vector3 dir)
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.z))
        {
            if (dir.x > 0)
                return viewDirection.RIGHT;
            else if (agent.velocity.x < 0)
                return viewDirection.LEFT;
            else
                return viewDirection.NULL;
        }
        else
        {
            if (dir.z > 0)
                return viewDirection.TOWARD;
            else if (dir.z < 0)
                return viewDirection.DOWN;
            else
                return viewDirection.NULL;
        }
    }

    public void SetUp()
    {
        player = FindObjectOfType<PlayerLogic>();
        agent = GetComponent<NavMeshAgent>();
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
                obj.transform.position = this.transform.position;
                obj.Init();
            }
            Destroy(this.gameObject);
        }
    }

    
}
