using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MovementState
{
    FREE_MOVE,
    FOLLOW_PLAYER
}


public class AIMovementComponent
{
    private NavMeshAgent agent;
    private int currentTargetIndex;
    private int dir;
    private Vector3[] targets;
    private Transform player;
    private Indicator indicator;
    
    public MovementState currentState { get; private set; }
    public viewDirection currentView { get; private set; }
    public bool canMove = true;


    /// <summary>
    /// Осуществляет движение объекта к цели
    /// </summary>
    public void Move()
    {
        // Если объект может двигаться
        if (canMove)
        {
            // Если объект находиться в состоянии свободного движения,
            // то двигается по маршруту
            if (currentState == MovementState.FREE_MOVE)
            {
                agent.SetDestination(targets[currentTargetIndex]);

                if (Vector3.Distance(targets[currentTargetIndex], agent.transform.position) <= agent.stoppingDistance)
                {
                    currentTargetIndex += dir;
                    if (currentTargetIndex >= targets.Length || currentTargetIndex < 0)
                    {
                        currentTargetIndex -= dir;
                        dir *= -1;
                    }
                }
            }
            
            // Иначе следует за игроком
            else
                agent.SetDestination(player.position);

            if (agent.velocity != Vector3.zero)
                currentView = DetermineView(agent.velocity);
        }
        else
            agent.SetDestination(agent.transform.position);

        // Определяем, находиться ли игрок достаточно близко,
        // чтобы начать следовать за ним
        if (currentState == MovementState.FREE_MOVE)
        {
            if (Vector3.Distance(player.position, agent.transform.position) <= 1)
            {
                currentState = MovementState.FOLLOW_PLAYER;
                indicator.SetIndicator();
            }
        }
    }


    /// <summary>
    /// Создает новый компонент AIMovementComponent
    /// </summary>
    /// <param name="agent">Агент, через которого осуществляется движение</param>
    /// <param name="path">Путь свободного движения</param>
    /// <param name="player">Игрок, за которым надо будет следовать</param>
    public AIMovementComponent(NavMeshAgent agent, Vector3[] path, Transform player, Indicator indicator)
    {
        this.agent = agent;
        this.targets = path;
        this.dir = 1;
        this.currentTargetIndex = 0;
        this.player = player;
        this.currentState = MovementState.FREE_MOVE;
        this.indicator = indicator;

        //this.agent.stoppingDistance *= 3;
    }


    /// <summary>
    /// Расстояние до цели
    /// </summary>
    /// <returns></returns>
    public float GetDistanceToTarget()
    {
        if (currentState == MovementState.FREE_MOVE)
            return Vector3.Distance(targets[currentTargetIndex], agent.transform.position);
        else
            return Vector3.Distance(agent.transform.position, player.position);
    }


    /// <summary>
    /// Возвращает агента
    /// </summary>
    /// <returns></returns>
    public NavMeshAgent GetAgent()
    {
        return agent;
    }


    /// <summary>
    /// Переводи вектор в один из четырёх: вперед, назад, вправо, влево
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    public viewDirection DetermineView(Vector3 dir)
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
                return viewDirection.UP;
            else if (dir.z < 0)
                return viewDirection.DOWN;
            else
                return viewDirection.NULL;
        }
    }


    public Vector3 DetermineView(viewDirection view)
    {
        switch (view)
        {
            case viewDirection.UP:
                return Vector3.forward;
            case viewDirection.DOWN:
                return Vector3.back;
            case viewDirection.RIGHT:
                return Vector3.right;
            case viewDirection.LEFT:
                return Vector3.left;
            
            default:
                return Vector3.zero;
        }
    }


    /// <summary>
    /// Толчок от цели
    /// </summary>
    public void PushFromTarget()
    {
        agent?.Move((agent.transform.position - player.position).normalized * 0.5f);
    }
}
