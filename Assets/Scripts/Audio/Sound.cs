using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

[System.Serializable]
public class Sound
{
    public AudioClip sound;
    public string name;
    [Range(0f, 1f)] public float volume = 0.4f;
    [Range(0.1f, 3f)] public float pitch = 1f;

    public bool loop;

    [HideInInspector] public AudioSource source;

    public UnityEvent OnFinishPlaying;
}
