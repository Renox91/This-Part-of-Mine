using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;
    public static DialogueManager Instance { get { return _instance; } }

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private Animator animator;

    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [SerializeField] private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        PlayerMovement.Move = 0;
        PlayerMovement.CanMove = false;
        DialogueTrigger.IsTalking = true;

        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        PlayerMovement.CanMove = true;
        DialogueTrigger.IsTalking = false;
        Debug.Log("End Conversation");
    }

    public bool IsQueueEmpty()
    {
        return sentences.Count == 0;
    }
}
