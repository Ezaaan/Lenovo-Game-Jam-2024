using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TestLilNiggaController : MonoBehaviour
{
    public float speed = 5f;

    Vector3 targetPosition;

    public void SetTargetPos(Vector3 position) {
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
        }
    }
}
