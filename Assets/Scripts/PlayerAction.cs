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
    public Animator animator;
    //private GameManager gameManager;
    private MotherAudio motherAudio;
    private void Awake()
    {
        //gameManager = GameManager.instance;
        motherAudio = GetComponent<MotherAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(playerInput.SpecialAction))
        {
            if (GameManager.instance.isMotherActive && gameObject.tag=="mommy") {
                //momCall.Play();
                animator.SetBool("isCalling", true);
                CallAction(); 
                //animator.SetBool("isCalling", false);
            }
            else { PossessAction(); }
        }

        if (Input.GetKeyUp(playerInput.SpecialAction))
        {
            if (GameManager.instance.isMotherActive && gameObject.tag == "mommy")
            {
                animator.SetBool("isCalling", false);
            }
        }
    }

    void CallAction()
    {
        motherAudio.PlayCallChildVoice();
        child.GetComponent<ChildController>().SetTargetPos(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
    }

    void PossessAction()
    {

    }
}
