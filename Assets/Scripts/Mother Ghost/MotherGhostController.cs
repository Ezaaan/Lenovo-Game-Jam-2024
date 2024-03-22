using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MilfGhostController : MonoBehaviour
{
    public GameObject receivingObject;
    private MotherAudio motherAudio;

    public float speed = 5f;
    private void Awake() {
        motherAudio = GetComponent<MotherAudio>();
    }
    public void MoveLeft() {transform.position -= speed * Time.deltaTime * transform.right;}
    public void MoveRight() {transform.position += speed * Time.deltaTime * transform.right;}
    public void CallLilNigga() {
        receivingObject.GetComponent<ChildController>().SetTargetPos(transform.position);
        motherAudio.PlayCallChildVoice();
    }
}
