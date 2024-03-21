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


    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            checkColiders();
        }
    }

    void checkColiders()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 20f);

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.gameObject.tag == "Possessable")
            {
                SpriteRenderer spr = collider.gameObject.GetComponent<SpriteRenderer>();
                spr.color = Color.blue;
            }
        }
    }
}
