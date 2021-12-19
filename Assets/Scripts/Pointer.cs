using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Transform target; // объект за которым надо следить


    /// <summary>
    /// Устанавливает цель для указателя
    /// </summary>
    /// <param name="target">Цель</param>
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        // Направление на цель
        Vector3 dir = target.position - transform.position;

        // Угол поворота вычисляется по формуле:
        // угол = арккосинус (скалярное произведение между векторами / умножение длин этих векторов)
        var zRot = Mathf.Acos(Vector3.Dot(Vector3.forward, dir) / dir.magnitude) * Mathf.Rad2Deg;

        if (Vector3.Cross(Vector2.up, dir).z < 0)
            zRot *= -1;
        
        transform.rotation = Quaternion.Euler(90, 0, zRot);
    }
}
