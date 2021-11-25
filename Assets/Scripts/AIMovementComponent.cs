using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovementComponent
{
    NavMeshAgent agent;
    Transform target;
    public viewDirection currentView { get; private set; }


    /// <summary>
    /// Осуществляет движение объекта к цели
    /// </summary>
    public void Move()
    {
        agent.SetDestination(target.position);
        if (agent.velocity != Vector3.zero)
            currentView = DetermineView(agent.velocity);
    }


    /// <summary>
    /// Создает новый компонент AIMovementComponent
    /// </summary>
    /// <param name="agent">Агент, через которого осуществляется движение</param>
    /// <param name="target">Цель движения</param>
    public AIMovementComponent(NavMeshAgent agent, Transform target)
    {
        this.agent = agent;
        this.target = target;

        this.agent.stoppingDistance *= 3;
    }


    /// <summary>
    /// Расстояние до цели
    /// </summary>
    /// <returns></returns>
    public float GetDistanceToTarget()
    {
        return Vector3.Distance(agent.transform.position, target.transform.position);
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


    /// <summary>
    /// Толчок от цели
    /// </summary>
    public void PushFromTarget()
    {
        agent?.Move((agent.transform.position - target.transform.position).normalized * 0.5f);
    }
}
