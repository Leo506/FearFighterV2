﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour, IGetDamaged, ISetUpObj
{
    [SerializeField] DroppingObj coin;
    [SerializeField] float hp = 100;
    [SerializeField] float attackRadius = 1;

    PlayerLogic player;
    Subject subject;
    bool canAttack = true;
    Pathfinding.AIPath path;
    viewDirection currentView = viewDirection.LEFT;

    public static int enemyCount = 0;

    private void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) <= path.endReachedDistance)
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
            else if (dir.x < 0)
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
        GetComponent<Pathfinding.AIDestinationSetter>().target = player.transform;
        path = GetComponent<AIPath>();
        path.endReachedDistance *= 5;
        subject = FindObjectOfType<Subject>();
        enemyCount++;


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
    }


    public void MyQueue()
    {
        path.endReachedDistance /= 5;
    }
    
}
