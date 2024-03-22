using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public Sound[] sounds;
    private Sound playedBGM;
    [SerializeField] private UnityEvent OnSceneLoaded;

    private void Awake() {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    private void Start() {
        OnSceneLoaded?.Invoke();
    }

    public void PlaySFX(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();

        if (!s.loop && s.OnFinishPlaying != null) {
            StartCoroutine(HandleOnAudioFinish(s));
        }
    }

    public void PlayBGM(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        playedBGM?.source.Stop();
        playedBGM = s;
        s.source.Play();

        if (!s.loop && s.OnFinishPlaying != null) {
            StartCoroutine(HandleOnAudioFinish(s));
        }
    }

    public IEnumerator HandleOnAudioFinish(Sound s) {
        yield return null;
        while (s.source.isPlaying) {
            yield return null;
        }
        s.OnFinishPlaying.Invoke();
    }
}
