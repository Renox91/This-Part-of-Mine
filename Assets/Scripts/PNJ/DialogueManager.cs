using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private bool endMode;
    private static DialogueManager _instance;
    public static DialogueManager Instance { get { return _instance; } }

    public bool EndMode { get => endMode; set => endMode = value; }

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private Animator animator;

    private UnityEvent endEvent;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
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
        animator.SetBool("IsOpen", false);
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

        endEvent = dialogue.endEvent;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartDialogueInfo(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        endEvent = dialogue.endEvent;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (endMode)
        {
            if (sentences.Count == 4)
            {
                FindObjectOfType<DialogueTriggerBunny>().SadLapine();
            }
            else if (sentences.Count == 1)
            {
                FindObjectOfType<DialogueTriggerBunny>().KissLapine();
            }
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            endEvent.Invoke();
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

    public void EndDialogue()
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
