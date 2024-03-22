using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject daddy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.name == "Key") {
            Debug.Log("destoryer");
            col.gameObject.GetComponent<Collider2D>().enabled = false;
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            daddy.GetComponent<PlayerMovement>().enabled = true;
            daddy.GetComponent<FatherController>().enabled = true;
            daddy.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
