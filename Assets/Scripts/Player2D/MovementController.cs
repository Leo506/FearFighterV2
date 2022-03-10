using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] float speed;  // Скорость движения
        [SerializeField] Joystick joystick;
        Rigidbody2D rb;
        Vector2 direction;

        private void Start() 
        {
            rb = GetComponent<Rigidbody2D>();   
        }

        private void Update() 
        {
            direction = joystick.Direction;   
        }

        private void FixedUpdate() 
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;   
        }
    }
}
