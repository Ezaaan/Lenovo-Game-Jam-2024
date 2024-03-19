using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaddyController : MonoBehaviour
{
    private float horizontal, vertical;
    private float speed = 10f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2 (horizontal * speed, vertical * speed);
    }
}
