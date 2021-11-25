using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackComponent
{
    BoxCollider box;
    Transform objTransform;
    int layerMask;

    public RaycastHit hit;

    /// <summary>
    /// Создаёт компонет AttackComponent
    /// </summary>
    /// <param name="collider">Коллайдер объекта</param>
    /// <param name="transform">Transform объекта</param>
    /// <param name="layer">LayerMask объетков, которые можно атаковать</param>
    public AttackComponent(BoxCollider collider, Transform transform, int layer = Physics.DefaultRaycastLayers)
    {
        box = collider;
        layerMask = layer;
        objTransform = transform;
    }


    /// <summary>
    /// Атака
    /// </summary>
    /// <param name="dir">Направление атаки</param>
    /// <param name="distance">Максимальное расстояние</param>
    public void Attack(Vector3 dir, float distance)
    {
        Vector3 center = objTransform.position + dir * distance;
        Vector3 size = new Vector3(
            box.size.x * objTransform.localScale.x,
            box.size.y * objTransform.localScale.y,
            box.size.z * objTransform.localScale.z
            );

        if (Physics.OverlapBox(center, size / 2, objTransform.rotation, layerMask).Length != 0)
        {
            Debug.Log("Hit!!!");
        }
    }
}
