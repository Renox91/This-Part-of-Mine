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
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetButtonDown("Talk"))
            {
                if (!isTalking)
                {
                    if (!quest.QuestIsAccepted || !quest.QuestIsFinished)
                    {
                        //Dialogue de début de quête
                        quest.QuestIsAccepted = true;
                        TriggerDialogue(dialogueStart);
                        Debug.Log("Dialogue_Start");
                    }
                    else if (quest.QuestIsFinished)
                    {
                        //Dialogue de quête finie
                        TriggerDialogue(dialogueEnd);
                        GetComponent<Quest01>().EndQuest();
                    }
                }
                else
                {
                    DialogueManager.Instance.DisplayNextSentence();
                }
            }
            else if (isTalking && Input.GetButtonDown("Jump"))
            {
                isTalking = false;
                cinemachineSwitcher.StopScene(boolTagScene);
                DialogueManager.Instance.EndDialogue();
            }
        }

        if (!isTalking && cinemachineSwitcher.isCutSceneOn)
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

    private void TriggerDialogue(Dialogue dialogue)
    {
        // Code pour trigger la boite de dialogue avec les paramètres
        cinemachineSwitcher.StartScene(boolTagScene);
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
