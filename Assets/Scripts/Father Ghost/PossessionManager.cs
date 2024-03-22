using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PossessionManager : MonoBehaviour
{
    public static PossessionManager instance;
    public GameObject daddy;
    private bool objectCotrolled = false;

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
        daddy.GetComponent<FatherController>().enabled = false;
        daddy.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
        obj.GetComponent<ObjectMovement>().enabled = true;
        obj.GetComponent<Rigidbody2D>().gravityScale = 0;
        obj.GetComponent<PossesionController>().enabled = true;
        GameManager.instance.isControllingObject = true;
    }

    public void SetControlToPlayer(Object obj)
    {
        obj.GetComponent<ObjectMovement>().enabled = false;
        obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        obj.GetComponent<PossesionController>().enabled = false;
        daddy.GetComponent<PlayerMovement>().enabled = true;
        daddy.GetComponent<FatherController>().enabled = true;
        daddy.GetComponent<SpriteRenderer>().color = Color.white;

        GameManager.instance.isControllingObject = false;
        Debug.Log("adwadwa");
    }
}
