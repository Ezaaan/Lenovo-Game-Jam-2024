using UnityEngine;

public class MotherAudio : MonoBehaviour
{
    private readonly string[] callVoiceList = { "Mommy1", "Mommy2" };

    public void PlayCallChildVoice() {
        AudioManager.Instance.PlaySFX(callVoiceList[Random.Range(0, callVoiceList.Length)]);
    }
}
