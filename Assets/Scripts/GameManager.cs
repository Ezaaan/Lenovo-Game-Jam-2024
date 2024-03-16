using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isFollowingMommy = true;
    private CameraHandler cameraHandler;
    private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {

        camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraHandler = camera.GetComponent<CameraHandler>();
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
            }
            else
            {
                cameraHandler.changeTarget("mommy");
                isFollowingMommy = true;
            }
        }
    }
}
