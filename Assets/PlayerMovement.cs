using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum viewDirection
{
    TOWARD,
    DOWN,
    RIGHT,
    LEFT
}
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;
    viewDirection currentDirection = viewDirection.RIGHT;
    BoxCollider box;

    public float speed = 100;
    public Joystick joystick;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
        if (Mathf.Abs(joystick.Vertical) > Mathf.Abs(joystick.Horizontal))
        {
            if (joystick.Vertical > 0)
                currentDirection = viewDirection.TOWARD;
            else if (joystick.Vertical < 0)
                currentDirection = viewDirection.DOWN;
        } else
        {
            if (joystick.Horizontal > 0)
                currentDirection = viewDirection.RIGHT;
            else if (joystick.Horizontal < 0)
                currentDirection = viewDirection.LEFT;
        }
    }

    public void Fire()
    {
        RaycastHit hit;
        Vector3 rayDir;
        float distance;

        switch (currentDirection)
        {
            case viewDirection.TOWARD:
                rayDir = Vector3.forward;
                distance =  box.size.z;
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

    private void FixedUpdate()
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
