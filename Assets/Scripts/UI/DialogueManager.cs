using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private Sound typingSound;

    private int index;

    private void Awake() {
        if (!textComponent) textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

        AudioManager.Instance.GetSound("Typing");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                AudioManager.Instance.GetSound("Typing").source.Stop();
                textComponent.text = lines[index];
            }
        }
    }

    IEnumerator TypeLine()
    {
        AudioManager.Instance.PlaySFX("Typing");
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        AudioManager.Instance.GetSound("Typing").source.Stop();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }


    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else
        {
            SceneManagerController.Instance.LoadScene("Level");
        }
    }

    
}
