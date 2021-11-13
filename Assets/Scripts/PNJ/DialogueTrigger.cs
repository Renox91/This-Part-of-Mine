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
    [SerializeField] private startCutScene cutScene;

    public static bool IsTalking
    {
        get { return isTalking; }
        set { isTalking = value; }
    }

    private void Start()
    {
        cutScene = GetComponentInChildren<startCutScene>();
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
                cutScene.StartCutScene();
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
        else if(isTalking == false && cutScene.isCutSceneOn)
        {
            cutScene.StopCutScene();
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
        cutScene.StartCutScene();
        DialogueManager.Instance.StartDialogue(dialogueStart);
    }
}
