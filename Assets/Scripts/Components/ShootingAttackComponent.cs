using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttackComponent
{
    ShootObj shootPrefab;
    Transform targetTransform;

    Transform shooterTransform;

    /// <summary>Создаёт компонент стрельбы</summary>
    /// <param name="obj">Префаб снаряда</param>
    /// <param name="target">Цель стрельбы</param>
    /// <param name="shooter">Стреляющий</param>
    public ShootingAttackComponent(ShootObj obj, Transform target, Transform shooter)
    {
        shootPrefab = obj;
        targetTransform = target;
        shooterTransform = shooter;
    }


    /// <summary>Стрельба</summary>
    public void Attack()
    {
        var shoot = GameObject.Instantiate(shootPrefab);
        shoot.transform.position = shooterTransform.position;
        shoot.SetDir((targetTransform.position - shooterTransform.position).normalized);
        
    }
}
