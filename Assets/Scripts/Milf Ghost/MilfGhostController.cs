using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MilfGhostController : MonoBehaviour
{
    bool isCalling = false;
    GameObject receivingObject;

    public float speed = 5f;
    public void MoveLeft() {transform.position -= speed * Time.deltaTime * transform.right;}
    public void MoveRight() {transform.position += speed * Time.deltaTime * transform.right;}
    public void CallLilNigga() {isCalling = true;}

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        if(isCalling) {
            receivingObject = GameObject.Find ("lil nigga");
            receivingObject.SendMessage("SetTargetPos", transform.position);
            isCalling = false;
        }
    }
}