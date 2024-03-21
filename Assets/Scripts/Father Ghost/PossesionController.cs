using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossesionController : MonoBehaviour
{
    private bool isPlayerNearby = false;
    private bool isControlled = false;

    private void Update()
    {
        if (!isControlled)
        {
            if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("eeee");
                PossessionManager.instance.SetControlToObject(this.gameObject);
                isControlled = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("EEEE");
                PossessionManager.instance.SetControlToPlayer(this.gameObject);
                isControlled = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("daddy"))
        {
            isPlayerNearby = true;
            Debug.Log("Player is now in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("daddy"))
        {
            isPlayerNearby = false;
            Debug.Log("Player is now not in range");
        }
    }
}
