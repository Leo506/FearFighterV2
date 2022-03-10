using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackComponent
{
    BoxCollider2D box;  // Коллайдер объекта, к которому привязан компонент
    Transform objTransform;  // Трансформ этого объекта
    int layerMask;           // Маска

    public RaycastHit hit;

    /// <summary>
    /// Создаёт компонет AttackComponent
    /// </summary>
    /// <param name="collider">Коллайдер объекта</param>
    /// <param name="transform">Transform объекта</param>
    /// <param name="layer">LayerMask объетков, которые можно атаковать</param>
    public AttackComponent(BoxCollider2D collider, Transform transform, int layer = Physics.DefaultRaycastLayers)
    {
        box = collider;
        layerMask = layer;
        objTransform = transform;
    }


    /// <summary>
    /// Атака
    /// </summary>
    /// <param name="dir">Направление атаки</param>
    /// <param name="damageValue">Количество урона</param>
    public virtual void Attack(Vector2 dir, float damageValue)
    {
        Vector2 point = (Vector2)objTransform.position + dir;
        Vector2 size = box.size * objTransform.localScale.x;

        Collider2D collider = Physics2D.OverlapBox(point, size, 0);
        Debug.Log("Collider: " + collider);
        collider?.GetComponent<IGetDamaged>()?.GetDamage(damageValue);
    }


    /// <summary>
    /// Атака
    /// </summary>
    public virtual void Attack()
    {

    }
}
