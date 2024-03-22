using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour
{
    /* Inspector fields */
    [Header("Input Settings")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Player Settings")]
    [SerializeField] private float maxSpeed = 5f;
    public float CurrentSpeed { get; private set; } = 0;
    [SerializeField] private float timeToAccelerate = 0.2f;

    [Header("Boundary Settings")]
    [SerializeField] private float lowerMarginX = 0.05f;
    [SerializeField] private float lowerMarginY = 0.05f;
    [SerializeField] private float upperMarginX = 0.95f;
    [SerializeField] private float upperMarginY = 0.95f;
    private float acceleration;

    private Vector2 forcedInput;


    /* Private fields */
    private Vector3 move; // Store the move on the current frame

    private void Awake()
    {
        acceleration = maxSpeed / timeToAccelerate;
    }

    void Update()
    {
        if (!GameManager.instance.isControllingObject)
        {
            return;
        }
        Vector2 moveInput = playerInput.MoveInput;
        forcedInput = new(CheckBoundaryX(moveInput.x), CheckBoundaryY(moveInput.y));
        Debug.Log($"X: {moveInput.x}");
        move = new(forcedInput.x, forcedInput.y, 0);

        CurrentSpeed += acceleration * Time.fixedDeltaTime;
        CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0, maxSpeed);

        // If the input is 0, use the buffer to maintain the last movement until current speed is 0
        Vector3 appliedMove = move;
        transform.position += CurrentSpeed * Time.fixedDeltaTime * appliedMove;
    }

    private void FixedUpdate()
    {
    }

    private float CheckBoundaryX(float input)
    {
        Vector2 bottomLeft = GameManager.instance.GetCamera().ViewportToWorldPoint(new Vector3(lowerMarginX, lowerMarginY, GameManager.instance.GetCamera().nearClipPlane));
        Vector2 topRight = GameManager.instance.GetCamera().ViewportToWorldPoint(new Vector3(upperMarginX, upperMarginY, GameManager.instance.GetCamera().nearClipPlane));
        Debug.Log($"TOPRIGHTX: {topRight.x}");
        Debug.Log($"positionX: {transform.position.x}");
        if ((transform.position.x <= bottomLeft.x && input == -1) || (transform.position.x >= topRight.x && input == 1))
        {
            input = 0;
        }

        return input;
    }

    private float CheckBoundaryY(float input)
    {
        Vector2 bottomLeft = GameManager.instance.GetCamera().ViewportToWorldPoint(new Vector3(lowerMarginX, lowerMarginY, GameManager.instance.GetCamera().nearClipPlane));
        Vector2 topRight = GameManager.instance.GetCamera().ViewportToWorldPoint(new Vector3(upperMarginX, upperMarginY, GameManager.instance.GetCamera().nearClipPlane));
        if ((transform.position.y <= bottomLeft.y && input == -1) || (transform.position.y >= topRight.y && input == 1))
        {
            input = 0;
        }

        return input;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Debug.Log(collision.gameObject.tag);
    //    if(collision.gameObject.tag == "Floor")
    //    {
    //        //Debug.Log("hit floor");
    //        forcedInput.y = 0;
    //    }
    //}
}