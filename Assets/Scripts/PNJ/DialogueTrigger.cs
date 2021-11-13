using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueStart;
    [SerializeField] private Dialogue dialogueEnd;
    [SerializeField] private bool isInRange = false;
    [SerializeField] private Quest quest;
    [SerializeField] private static bool isTalking = false;
    [SerializeField] private CinemachineSwitcher cinemachineSwitcher;
    [SerializeField] private string boolTagScene;

    public static bool IsTalking
    {
        get { return isTalking; }
        set { isTalking = value; }
    }

    private void Start()
    {
        
    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !quest.QuestIsAccepted && IsTalking == false)
        {
            //Dialogue de d�but de qu�te
            quest.QuestIsAccepted = true;
            TriggerDialogue();
        }
        else if(isInRange && Input.GetKeyDown(KeyCode.E) && quest.QuestIsAccepted && IsTalking == false)
        {
            if(quest.QuestIsFinished)
            {
                //Dialogue de qu�te finie
                cinemachineSwitcher.StartScene(boolTagScene);
                DialogueManager.Instance.StartDialogue(dialogueEnd);
            }
            else
            {
                //Dialogue de qu�te en cours
                TriggerDialogue();
            }
        }
        else if(isTalking && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.Instance.DisplayNextSentence();
        }
        else if(isTalking == false && cinemachineSwitcher.isCutSceneOn)
        {
            cinemachineSwitcher.StopScene(boolTagScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isInRange = false;
    }

    private void TriggerDialogue()
    {
        // Code pour trigger la boite de dialogue avec les param�tres
        cinemachineSwitcher.StartScene(boolTagScene);
        DialogueManager.Instance.StartDialogue(dialogueStart);
    }
}
