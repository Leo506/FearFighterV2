using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObj : MonoBehaviour
{
    protected Transform playerTransform;
    protected bool canMove = false;
    public float speed = 10.0f;

    private void Update() 
    {
        if (canMove)
        {
            this.transform.Translate((playerTransform.position - this.transform.position).normalized * speed * Time.deltaTime);    
            if (Vector3.Distance(playerTransform.position, this.transform.position) <= 0.1f)
                OnGet();
        }
    }


    /// <summary>
    /// Начать движение
    /// </summary>
    public void StartMove(Transform transform)
    {
        canMove = true;
        playerTransform = transform;
    }

    protected virtual void OnGet()
    {
        Debug.Log("Использование дропа");
        Destroy(this.gameObject);
    }
}
