using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    PlayerMovement movement;
    BoxCollider box;
    
    [SerializeField] Animator animator;

    /// <summary>
    /// Настройка игрока
    /// </summary>
    public void SetUpPlayer()
    {
        FindObjectOfType<Cinemachine.CinemachineVirtualCamera>().Follow = this.transform;
        movement = GetComponent<PlayerMovement>();
        box = GetComponent<BoxCollider>();
    }


    /// <summary>
    /// Атака игрока
    /// </summary>
    public void Attack()
    {
        RaycastHit hit;
        Vector3 rayDir;
        float distance;

        switch (movement.currentViewDirection)
        {
            case viewDirection.TOWARD:
                rayDir = Vector3.forward;
                distance = box.size.z;
                break;
            case viewDirection.DOWN:
                rayDir = Vector3.back;
                distance = box.size.z;
                break;
            case viewDirection.RIGHT:
                rayDir = Vector3.right;
                distance = box.size.x;
                break;
            case viewDirection.LEFT:
                rayDir = Vector3.left;
                distance = box.size.x;
                break;
            default:
                rayDir = Vector3.zero;
                distance = box.size.x;
                break;
        }

        if (Physics.Raycast(this.transform.position, rayDir, out hit, distance))
        {
            Debug.Log("Attack the " + hit.collider.gameObject.name);
            hit.collider.GetComponent<EnemyController>()?.GetDamage(10);
        }
        Debug.DrawLine(transform.position, transform.position + rayDir * distance, Color.red);
        animator.SetTrigger("Attack");
    }
}
