using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PossessionManager : MonoBehaviour
{
    public static PossessionManager instance;
    public GameObject daddy;

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

    public void SetControlToObject(Object obj)
    {
        daddy.GetComponent<PlayerMovement>().enabled = false;
        foreach (var movableObject in FindObjectsOfType<PlayerMovement>())
        {
            movableObject.enabled = false;
        }

        obj.GetComponent<PlayerMovement>().enabled = true;
        obj.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void SetControlToPlayer(Object obj)
    {
        obj.GetComponent<PlayerMovement>().enabled = false;
        obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        daddy.GetComponent<PlayerMovement>().enabled = true;
    }
}
