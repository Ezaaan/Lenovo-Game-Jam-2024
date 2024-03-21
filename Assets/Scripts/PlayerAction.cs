using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    /* Inspector fields */
    [Header("Input Settings")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Player Settings")]
    [SerializeField] private GameObject child;
    [SerializeField] private float maxSpeed = 5f;
    public float CurrentSpeed { get; private set; } = 0;
    [SerializeField] private float timeToAccelerate = 0.2f;
    private float acceleration;
    [SerializeField] private float timeToDecelerate = 0.12f;
    private float deceleration;

    private bool isInputActive = true;
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerInput.SpecialAction))
        {
            if (gameObject.tag == "mommy") { CallAction(); }
            else { PossessAction(); }
        }
    }

    void CallAction()
    {
        child.GetComponent<ChildController>().SetTargetPos(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
    }

    void PossessAction()
    {

    }
}
