using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    /* Inspector fields */
    [Header("Input Settings")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Player Settings")]
    [SerializeField] private float maxSpeed = 5f;
    public float CurrentSpeed { get; private set; } = 0;
    [SerializeField] private float timeToAccelerate = 0.2f;
    private float acceleration;
    [SerializeField] private float timeToDecelerate = 0.12f;
    private float deceleration;

    private bool isInputActive = true;


    /* Private fields */
    private const int LEFT = -1;
    private const int RIGHT = 1;
    private int lookDirection;
    private Vector3 move; // Store the move on the current frame
    private Vector3 previousMove; // Store the move on the previous frame
    private Vector3 bufferMove; // Store the last move before the input went to 0

    private void Awake()
    {
        lookDirection = transform.rotation.y == 0 ? RIGHT : LEFT;
        acceleration = maxSpeed / timeToAccelerate;
        deceleration = maxSpeed / timeToDecelerate;
    }

    void Update()
    {
        if (!isInputActive)
        {
            return;
        }
        // Input
        Vector2 moveInput = playerInput.MoveInput;
        previousMove = move;
        move = new(moveInput.x, moveInput.y, 0);

        if (previousMove.magnitude > 0 && move.magnitude == 0)
        {
            bufferMove = previousMove;
        }

        // Flip the player if the direction changes
        if (Mathf.Sign(move.x) != lookDirection && move.x != 0)
        {
            lookDirection = (int)Mathf.Sign(move.x);

            int yRot = lookDirection == 1 ? 0 : 180;
            transform.rotation = Quaternion.Euler(0, yRot, 0);
        }

        CurrentSpeed += acceleration * Time.deltaTime;


        CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0, maxSpeed);

        // If the input is 0, use the buffer to maintain the last movement until current speed is 0
        Vector3 appliedMove = move;
        transform.position += CurrentSpeed * Time.deltaTime * appliedMove;
    }

    private void FixedUpdate()
    {
        
        
        //CurrentSpeed += acceleration * Time.fixedDeltaTime;
        

       // CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0, maxSpeed);

        // If the input is 0, use the buffer to maintain the last movement until current speed is 0
        //Vector3 appliedMove = move;
        //transform.position += CurrentSpeed * Time.fixedDeltaTime * appliedMove;
    }

    public void SetInputActive(bool _isActive)
    {
        isInputActive = _isActive;
    }
}