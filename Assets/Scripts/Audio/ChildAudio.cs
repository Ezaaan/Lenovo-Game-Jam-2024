using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAudio : MonoBehaviour
{
    private ChildController child;
    private Sound footstepSound;
    
    private void Awake() {
        child = GetComponent<ChildController>();
    }

    private void Start() {
        AudioManager.Instance.PlaySFX("Footstep");
        footstepSound = AudioManager.Instance.GetSound("Footstep");
    }

    void Update()
    {
        if (child.isCalled) {
            footstepSound.source.volume = footstepSound.volume;
        } else {
            footstepSound.source.volume = 0;
        }
    }
}
