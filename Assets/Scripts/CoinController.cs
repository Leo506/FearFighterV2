using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;

    public float speed = 30;

    // Start is called before the first frame update
    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        direction = (FindObjectOfType<PlayerMovement>().transform.position - this.transform.position).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerMovement>() != null)
            Destroy(this.gameObject);
    }
}
