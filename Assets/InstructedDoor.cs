using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructedDoor : MonoBehaviour
{
    [SerializeField] private GameObject[] keys;

    private void Update()
    {
        if (isFulfilled())
        {
            gameObject.active = false;
        }
    }

    private bool isFulfilled()
    {
        foreach (var key in keys)
        {
            if (!key.GetComponent<InstructedPlacement>().IsPlaced())
            {
                return false;
            }
        }
        return true;
    }
}
