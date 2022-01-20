using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterEnemy : EnemyController, ISetUpObj, IGetDamaged
{
    [SerializeField] ShootObj shootPrefab;
    ShootingAttackComponent shooterAttack;
    private void Update()
    {
        if (movement != null)
        {
            movement.Move();

            if (movement.GetDistanceToTarget() <= attackRadius)
            {
                Debug.Log("can attack: " + canAttack);
                if (canAttack)
                    Attack();
            }
        }
    }


    protected override void Attack()
    {
        canAttack = false;
        shooterAttack.Attack();
        Invoke("Reload", delayTime);
    }


    public void SetUp()
    {
        player = FindObjectOfType<PlayerLogic>();

        id = enemyCount;
        enemyCount++;

        movement = new AIMovementComponent(GetComponent<NavMeshAgent>(), player.transform);

        box = GetComponent<BoxCollider>();
        shooterAttack = new ShootingAttackComponent(shootPrefab, player.transform, this.transform);
    }


}
