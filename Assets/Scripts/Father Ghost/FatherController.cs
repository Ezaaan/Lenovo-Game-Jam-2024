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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            checkColiders();
        }

        if (Input.GetKeyUp(KeyCode.Q) && hitColliders.Count > 0)
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

        if (Input.GetKey(KeyCode.Q))
        {
            if (Input.GetKeyDown(KeyCode.E) && hitColliders.Count > 0)
            {
                Debug.Log(index);
                int nextInd = index + 1;
                SpriteRenderer nxtspr = hitColliders[nextInd % hitColliders.Count].gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer spr = hitColliders[index % hitColliders.Count].gameObject.GetComponent<SpriteRenderer>();
                spr.color = Color.white;
                nxtspr.color = new Color(0, 0, 1, 0.3f);
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
