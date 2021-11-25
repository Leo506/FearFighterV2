using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, ISetUpObj
{
    PlayerMovement movement;
    BoxCollider box;
    AttackComponent attack;
    
    [SerializeField] Animator animator;
    [SerializeField] float distanceCoeff = 1;
    [SerializeField] UnityEngine.UI.Text text;  // TODO не забыть удалить
    [SerializeField] LayerMask attackLayer;

    // TODO Удалить
    void Start()
    {
        SetUp();
    }

    private void Update()
    {
        text.text = transform.position.ToString();
    }

    /// <summary>
    /// Настройка игрока
    /// </summary>
    public void SetUp()
    {
        movement = GetComponent<PlayerMovement>();
        box = GetComponent<BoxCollider>();
        attack = new AttackComponent(box, transform, attackLayer);
        //FindObjectOfType<Cinemachine.CinemachineVirtualCamera>().Follow = this.transform;
    }


    /// <summary>
    /// Атака игрока
    /// </summary>
    public void Attack()
    {

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

        attack.Attack(rayDir, distance);
        animator.SetTrigger("Attack");
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

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
        Gizmos.DrawRay(transform.position, rayDir * (distance - 0.03f));
        //Draw a cube at the maximum distance
        Gizmos.DrawWireCube(transform.position + rayDir * (distance - 0.03f), box.size);
    }
}
