using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildJump : MonoBehaviour
{
    public float rayDistance = 15f;
    public float jumpForce = 20f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;

    Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.0f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);


        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance);

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayDistance);

        Debug.DrawRay(transform.position, Vector2.right * rayDistance, Color.red);
        Debug.DrawRay(transform.position, Vector2.left * rayDistance, Color.red);
        
        if ((hitRight.collider != null || hitLeft.collider != null) && isGrounded)
        {
            Debug.Log("Jump");
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
