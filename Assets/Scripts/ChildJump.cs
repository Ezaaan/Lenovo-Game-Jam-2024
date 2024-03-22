using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildJump : MonoBehaviour
{
    public float rayDistance = 10f;
    public float jumpForce = 20f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    Vector2 RayOrigin;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RayOrigin = transform.position + new Vector3(0, -10f, 0);
        RaycastHit2D hitRight = Physics2D.Raycast(RayOrigin, Vector2.right, rayDistance);

        RaycastHit2D hitLeft = Physics2D.Raycast(RayOrigin, Vector2.left, rayDistance);

        Debug.DrawRay(RayOrigin, Vector2.right * rayDistance, Color.red);
        Debug.DrawRay(RayOrigin, Vector2.left * rayDistance, Color.red);

        
        if ((hitRight.collider != null || hitLeft.collider != null) && IsGrounded())
        {
            Debug.Log("Jump");
            Jump();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
