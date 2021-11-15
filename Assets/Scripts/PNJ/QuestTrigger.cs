using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") /*&& gameObject.GetComponentInParent<Quest>().QuestIsAccepted*/)
        {
            DialogueManager.Instance.StartDialogueInfo(dialogue);
            gameObject.GetComponentInParent<Quest>().QuestIsFinished = true;
            gameObject.SetActive(false);
            Invoke("StopInfo", 2.5f);
        }
    }

    private void StopInfo()
    {
        DialogueManager.Instance.EndDialogue();
    }
}
