using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ChildController : MonoBehaviour
{
    public float speed = 5f;
    public bool isCalled = false;
    Vector3 targetPosition;
    float threshold;

    private const int LEFT = -1;
    private const int RIGHT = 1;
    private int lookDirection;
    private bool hitSomething = false;
    private bool first = true;
    public bool righty;
    Vector2 prevPosition;

    public Animator animator;

    public void SetTargetPos(Vector3 position) {
        if (this.gameObject.GetComponent<ChildJump>().IsGrounded()) 
        {
            if (position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                righty = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                righty = false;
            }
            isCalled = true;
            threshold = .0f;
            targetPosition = position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }
    private void Awake()
    {
        first = true;
        lookDirection = transform.rotation.y == 0 ? RIGHT : LEFT;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(targetPosition.x - transform.position.x) >= 1.5f)
        {
            if (first)
            {
                Debug.Log("hek");
                first = false;
                animator.SetBool("isMoving", true);
            }
        }
        else
        {
            first = true;
            animator.SetBool("isMoving", false);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if(Mathf.Abs(targetPosition.x - transform.position.x) >= 1.5f) {
            
            if (Mathf.Sign(targetPosition.x) != lookDirection && targetPosition.x != 0)
            {

                lookDirection = (int)Mathf.Sign(targetPosition.x);

                int yRot = lookDirection == 1 ? 0 : 180;
                transform.rotation = Quaternion.Euler(0, yRot, 0);
            }
            Vector3 _direction = new(targetPosition.x - transform.position.x, 0f, 0f);
            transform.position += speed * Time.deltaTime * _direction.normalized;
            threshold += Time.deltaTime;
            Debug.Log(targetPosition.x);
            if (Mathf.Abs(threshold) >= 2f && hitSomething) { Debug.Log("stuck");  targetPosition = new(transform.position.x-1f, transform.position.y); }
            prevPosition = transform.position;
        } else {
            animator.SetBool("isMoving", false);
            Debug.Log("haha");
            isCalled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Floor") { Debug.Log("hit something"); hitSomething = true; return; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Floor") { Debug.Log("not hit anymore"); hitSomething = false; return; }

    }
}
