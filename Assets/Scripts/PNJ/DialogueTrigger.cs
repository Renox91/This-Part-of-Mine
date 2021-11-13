using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private bool isInRange = false;
    [SerializeField] private Quest quest;
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !quest.QuestIsAccepted)
        {
            TriggerDialogue();
            quest.QuestIsAccepted = true;
        }
        else if(isInRange && Input.GetKeyDown(KeyCode.E) && quest.QuestIsAccepted)
        {
            if(quest.QuestIsFinished)
            {
                //Dialogue de fin de qu�te
                // Ouverture de x objectifs
                gameObject.SetActive(false);
            }
            else
            {
                //Dialogue de qu�te
            }
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
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
