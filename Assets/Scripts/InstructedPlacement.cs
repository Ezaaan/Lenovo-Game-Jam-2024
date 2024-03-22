using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructedPlacement : MonoBehaviour
{
    [SerializeField] private bool isPlaced;
    [SerializeField] private GameObject key;
    [SerializeField] private float thresholdX;
    [SerializeField] private float thresholdY;

    private void Update()
    {
        CheckPlacement();
    }

    private void CheckPlacement()
    {
        //Debug.Log($"{key.name}: {Mathf.Abs(key.transform.position.x - transform.position.x)}");
        if (Mathf.Abs(key.transform.position.x - transform.position.x) <= thresholdX && Mathf.Abs(key.transform.position.y - transform.position.y) <= thresholdY){
            isPlaced = true;
        }
        else
        {
            //Debug.Log($"{key.name}: not placed");
            isPlaced = false;
        }
    }

    public bool IsPlaced()
    {
        return isPlaced;
    }
}
