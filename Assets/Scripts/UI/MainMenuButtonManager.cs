using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour
{
    private int activeButtonIdx;
    [SerializeField] private Image[] listOfButtonImage;
    [SerializeField] private float fadeDuration = 0.12f;

    private void Awake() {
        SetActiveButton(0);
    }

    public void SetActiveButton(int idx) {
        Image prevBtn = listOfButtonImage[activeButtonIdx];
        Image toBtn = listOfButtonImage[idx];

        StartCoroutine(FadeSpriteOut(prevBtn));
        StartCoroutine(FadeSpriteIn(toBtn));

        activeButtonIdx = idx;
    }

    private IEnumerator FadeSpriteIn(Image img) {
        float t = 0;
        while (t < fadeDuration) {
            t += Time.deltaTime;
            img.color = new Color(img.color.r, img.color.g, img.color.b, t / fadeDuration);
            yield return null;
        }
    }

    private IEnumerator FadeSpriteOut(Image img) {
        float t = fadeDuration;
        while (t > 0) {
            t -= Time.deltaTime;
            img.color = new Color(img.color.r, img.color.g, img.color.b, t / fadeDuration);
            yield return null;
        }
    }

}
