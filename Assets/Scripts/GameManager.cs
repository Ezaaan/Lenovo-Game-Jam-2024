using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isFollowingMommy = true;
    public bool isControllingObject = false;
    private CameraHandler cameraHandler;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private GameObject Father;
    [SerializeField] private GameObject Mother;
    public bool isMotherActive;
    

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

        cameraHandler = MainCamera.GetComponent<CameraHandler>();

        if (starter == starterGhost.mommy)
        {
            cameraHandler.changeTarget("mommy");
            isMotherActive = true;
            Mother.GetComponent<PlayerMovement>().SetInputActive(true);
            Father.GetComponent<PlayerMovement>().SetInputActive(false);
        }
        else
        {
            cameraHandler.changeTarget("daddy");
            isMotherActive = false;
            Mother.GetComponent<PlayerMovement>().SetInputActive(false);
            Father.GetComponent<PlayerMovement>().SetInputActive(true);

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
                isMotherActive = false;
                Mother.GetComponent<PlayerMovement>().SetInputActive(false);
                Father.GetComponent<PlayerMovement>().SetInputActive(true);

            }
            else
            {
                if (!isControllingObject)
                {
                    cameraHandler.changeTarget("mommy");
                    isFollowingMommy = true;
                    isMotherActive = true;
                    Mother.GetComponent<PlayerMovement>().SetInputActive(true);
                    Father.GetComponent<PlayerMovement>().SetInputActive(false);

                }
            }
        }
    }

    public Camera GetCamera()
    {
        return MainCamera;
    }
    public bool checkIfMotherActive()
    {
        return isMotherActive;
    }
}
