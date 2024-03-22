using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildJump : MonoBehaviour
{
    public float rayDistance = 15f;
    public float jumpForce = 25f;
    public float fallMultiplier = 1f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    Rigidbody2D rb;
    Vector2 RayOrigin;
    Vector2 fall;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fall = new Vector2(0, -Physics2D.gravity.y);
    }

    private void Update()
    {
        RayOrigin = transform.position + new Vector3(0, -10f, 0);
        RaycastHit2D hitRight = Physics2D.Raycast(RayOrigin, Vector2.right, rayDistance);

        RaycastHit2D hitLeft = Physics2D.Raycast(RayOrigin, Vector2.left, rayDistance);

        Debug.DrawRay(RayOrigin, Vector2.right * rayDistance, Color.red);
        Debug.DrawRay(RayOrigin, Vector2.left * rayDistance, Color.red);

        
        if ((hitRight.collider != null || hitLeft.collider != null) && IsGrounded() && this.gameObject.GetComponent<ChildController>().isCalled)
        {
            animator.SetBool("isManjat", true);
            Debug.Log(animator.GetBool("isManjat"));
            Debug.Log("Jump");
            Jump();
        }
        else
        {
           if(!(animator.GetCurrentAnimatorStateInfo(0).length >
           animator.GetCurrentAnimatorStateInfo(0).normalizedTime) && animator.GetCurrentAnimatorStateInfo(0).IsName("bocil_manjat"))
            {
                animator.SetBool("isManjat", false);
                Debug.Log("Jumpx");

            }
        }

        rb.velocity -= fall * fallMultiplier * Time.deltaTime;
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    private void Jump()
    {
        //animator.SetBool("isManjat", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
