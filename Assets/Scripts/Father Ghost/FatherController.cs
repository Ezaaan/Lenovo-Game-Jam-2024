using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FatherController : MonoBehaviour
{
    private float horizontal, vertical;
    private float speed = 10f;
    Rigidbody2D rb;
    List<Collider2D> hitColliders;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    private void Awake()
    {
        hitColliders = new List<Collider2D>();
    }

    private void FixedUpdate()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            checkColiders();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            SpriteRenderer spr = hitColliders[(index) % hitColliders.Count].gameObject.GetComponent<SpriteRenderer>();
            Debug.Log(spr);
            if (spr)
            {
                spr.color = Color.white;
                PossessionManager.instance.SetControlToObject(spr);
                index = 0;
                hitColliders.Clear();
            }


        }

        if (Input.GetKey(KeyCode.E))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log(index);
                int nextInd = index + 1;
                SpriteRenderer nxtspr = hitColliders[nextInd % hitColliders.Count].gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer spr = hitColliders[index % hitColliders.Count].gameObject.GetComponent<SpriteRenderer>();
                nxtspr.color = Color.blue;
                spr.color = Color.white;
                index++;
            }
        }

    }

    void checkColiders()
    {
        Collider2D[] hitCollides = Physics2D.OverlapCircleAll(transform.position, 20f);

        foreach (Collider2D collider in hitCollides)
        {
            if (collider.gameObject.tag == "Possessable")
            {
                hitColliders.Add(collider);
                Debug.Log(hitColliders.Count);
                Debug.Log(collider);

            }
        }
    }
}
