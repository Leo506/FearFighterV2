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
    /// <param name="damageValue">Количество урона</param>
    public virtual void Attack(Vector3 dir, float distance, float damageValue)
    {
        Debug.Log("Attack in attack component");
        Vector3 center = objTransform.position + dir * distance + new Vector3(0, box.center.y * objTransform.localScale.y, 0);
        Vector3 size = new Vector3(
            box.size.x * objTransform.localScale.x,
            box.size.y * objTransform.localScale.y,
            box.size.z * objTransform.localScale.z
            );

        Collider[] colliders = Physics.OverlapBox(center, size / 2, objTransform.rotation, layerMask);
        if (colliders.Length != 0)
        {
            Debug.Log("There are colliders");
            foreach (var item in colliders)
            {
                item.GetComponent<IGetDamaged>()?.GetDamage(damageValue);
            }
        }
    }


    /// <summary>
    /// Атака
    /// </summary>
    public virtual void Attack()
    {

    }
}
