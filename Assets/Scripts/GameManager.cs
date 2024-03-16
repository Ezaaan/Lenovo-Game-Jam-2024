using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isFollowingMommy = true;
    private CameraHandler cameraHandler;
    private GameObject camera;
    private MilfGhostInput milfGhostInput;

    // Start is called before the first frame update
    void Start()
    {

        camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraHandler = camera.GetComponent<CameraHandler>();
        milfGhostInput = GameObject.FindGameObjectWithTag("mommy").GetComponent<MilfGhostInput>();
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
            }
            else
            {
                cameraHandler.changeTarget("mommy");
                isFollowingMommy = true;
                milfGhostInput.SetInputActive(true);
            }
        }
    }
}
