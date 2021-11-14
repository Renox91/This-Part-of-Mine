using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutoDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private string boolTagScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerMovement.CanClimb)
        DialogueManager.Instance.StartDialogueInfo(dialogue);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!PlayerMovement.CanClimb)
            DialogueManager.Instance.EndDialogue();
    }

}
