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
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !quest.QuestIsAccepted && isTalking == false)
        {
            //Dialogue de début de quête
            quest.QuestIsAccepted = true;
            TriggerDialogue(dialogueStart);
            Debug.Log("Dialogue_Start");
        }
        else if(isInRange && Input.GetKeyDown(KeyCode.E) && quest.QuestIsAccepted && isTalking == false)
        {
            Debug.Log(1);
            if(quest.QuestIsFinished)
            {
                //Dialogue de quête finie
                TriggerDialogue(dialogueEnd);
                GetComponent<Quest01>().EndQuest();
            }
            else
            {
                //Dialogue de quête en cours
                TriggerDialogue(dialogueStart);
                Debug.Log("Dialogue_Start");
            }
        }
        else if(isInRange && isTalking && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(2);
            DialogueManager.Instance.DisplayNextSentence();
        }
        if(isTalking == false && cinemachineSwitcher.isCutSceneOn)
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
