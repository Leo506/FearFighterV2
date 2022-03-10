using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum viewDirection
{
    UP,
    DOWN,
    RIGHT,
    LEFT,
    NULL
}
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;                                                 // Направление движения

    public viewDirection currentViewDirection = viewDirection.RIGHT;   // В какую сторону смотрит игрок
    public float speed = 100;                                          // Скорость движения
    
    [SerializeField] Joystick joystick;                                // Управляющий джойстик


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //int multiplier = (CameraController.instance != null) ? ( (CameraController.instance.isReverse) ? -1 : 1) : 1;  //TODO переписать в удобочитаемом формате
        direction = joystick.Direction.normalized;
        if (Mathf.Abs(joystick.Vertical) > Mathf.Abs(joystick.Horizontal))
        {
            if (joystick.Vertical > 0)
                currentViewDirection = viewDirection.UP;
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
