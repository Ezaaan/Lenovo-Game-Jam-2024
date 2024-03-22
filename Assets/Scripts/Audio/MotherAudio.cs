using UnityEngine;

public class MotherAudio : MonoBehaviour
{
    private readonly string[] callVoiceList = { "Mommy" };

    public void PlayCallChildVoice() {
        AudioManager.Instance.PlaySFX(callVoiceList[Random.Range(0, callVoiceList.Length)]);
    }
}
