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

    private const int LEFT = -1;
    private const int RIGHT = 1;
    private int lookDirection;

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
    private void Awake()
    {
        lookDirection = transform.rotation.y == 0 ? RIGHT : LEFT;
    }

    // Update is called once per frame
    void Update()
    {

        if((int)targetPosition.x != (int)transform.position.x) {

            if (Mathf.Sign(targetPosition.x) != lookDirection && targetPosition.x != 0)
            {
                lookDirection = (int)Mathf.Sign(targetPosition.x);

                int yRot = lookDirection == 1 ? 0 : 180;
                transform.rotation = Quaternion.Euler(0, yRot, 0);
            }
            Vector3 _direction = new(targetPosition.x - transform.position.x, 0f, 0f);
            transform.position += speed * Time.deltaTime * _direction.normalized;
            threshold += Time.deltaTime;
            if (threshold >= 2f) { targetPosition = transform.position; }
        }
    }
}
