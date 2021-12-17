using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObj : MonoBehaviour
{
    Vector3 direction;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (direction != null)
            transform.Translate(direction * speed * Time.deltaTime);
    }


    /// <summary>
    /// Устанавливает направление движения снаряда
    /// </summary>
    /// <param name="dir">Направление (нормализированное)</param>
    public void SetDir(Vector3 dir)
    {
        direction = dir;
    }


    private void OnCollisionEnter(Collision other) 
    {
        other.collider.GetComponent<IGetDamaged>()?.GetDamage(10);
        Destroy(this.gameObject);    
    }
}
