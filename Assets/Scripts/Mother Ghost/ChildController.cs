using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ChildController : MonoBehaviour
{
    public float speed = 5f;
    public bool isCalled = false;
    Vector3 targetPosition;
    float threshold;

    public void SetTargetPos(Vector3 position) {
        isCalled = true;
        threshold = .0f;
        targetPosition = position;
        Debug.Log("called");
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if((int)targetPosition.x != (int)transform.position.x) {
            Vector3 _direction = new(targetPosition.x - transform.position.x, 0f, 0f);
            transform.position += speed * Time.deltaTime * _direction.normalized;
            threshold += Time.deltaTime;
            if (threshold >= 2f) { targetPosition = transform.position; }
        }
    }
}
