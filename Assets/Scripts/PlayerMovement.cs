using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum viewDirection
{
    TOWARD,
    DOWN,
    RIGHT,
    LEFT,
    NULL
}
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;                                                 // Направление движения

    public viewDirection currentViewDirection = viewDirection.RIGHT;   // В какую сторону смотрит игрок
    public float speed = 100;                                          // Скорость движения
    
    [SerializeField] Joystick joystick;                                // Управляющий джойстик


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
        if (Mathf.Abs(joystick.Vertical) > Mathf.Abs(joystick.Horizontal))
        {
            if (joystick.Vertical > 0)
                currentViewDirection = viewDirection.TOWARD;
            else if (joystick.Vertical < 0)
                currentViewDirection = viewDirection.DOWN;
        } else
        {
            if (joystick.Horizontal > 0)
                currentViewDirection = viewDirection.RIGHT;
            else if (joystick.Horizontal < 0)
                currentViewDirection = viewDirection.LEFT;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
