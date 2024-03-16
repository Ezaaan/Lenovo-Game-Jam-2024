using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MilfGhostController))]
public class MilfGhostInput : MonoBehaviour
{
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode actionWheel = KeyCode.Mouse2;

    bool wheelIsActive = false;
    Vector3 prevMousePos;

    MilfGhostController controller;
    bool isInputActive = true;
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<MilfGhostController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInputActive)
        {
            if (Input.GetKey(left)) controller.MoveLeft();
            if (Input.GetKey(right)) controller.MoveRight();

            if (Input.GetKeyDown(actionWheel))
            {
                prevMousePos = Input.mousePosition;
                wheelIsActive = true;
            }

            if (wheelIsActive)
            {
                Vector2 _delta = prevMousePos - Input.mousePosition;
                float _angle = Mathf.Atan2(_delta.y, _delta.x) * Mathf.Rad2Deg;
                _angle += 180;

                if (_angle >= 225 && Input.GetKeyUp(actionWheel))
                {
                    controller.CallLilNigga();
                    Debug.Log("test");
                }

            }
        }
    }
    public void SetInputActive(bool _isActive)
    {
        isInputActive = _isActive;
    }
}
