using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isFollowingMommy = true;
    public bool isControllingbject = false;
    private CameraHandler cameraHandler;
    private GameObject camera;
    private MilfGhostInput milfGhostInput;
    private PlayerMovement daddyInput;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private enum starterGhost
    {
        mommy,
        daddy
    }

    [SerializeField]
    private starterGhost starter = starterGhost.mommy;

    // Start is called before the first frame update
    void Start()
    {

        camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraHandler = camera.GetComponent<CameraHandler>();
        milfGhostInput = GameObject.FindGameObjectWithTag("mommy").GetComponent<MilfGhostInput>();
        daddyInput = GameObject.FindGameObjectWithTag("daddy").GetComponent<PlayerMovement>();

        if (starter == starterGhost.mommy)
        {
            cameraHandler.changeTarget("mommy");
            milfGhostInput.SetInputActive(true);
            daddyInput.SetInputActive(false);
        }
        else
        {
            cameraHandler.changeTarget("daddy");
            milfGhostInput.SetInputActive(false);
            daddyInput.SetInputActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFollowingMommy)
            {
                cameraHandler.changeTarget("daddy");
                isFollowingMommy = false;
                milfGhostInput.SetInputActive(false);
                daddyInput.SetInputActive(true);
            }
            else
            {
                if (!isControllingbject)
                {
                    cameraHandler.changeTarget("mommy");
                    isFollowingMommy = true;
                    milfGhostInput.SetInputActive(true);
                    daddyInput.SetInputActive(false);
                }
            }
        }
    }
}
