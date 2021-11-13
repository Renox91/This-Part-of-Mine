using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") /*&& gameObject.GetComponentInParent<Quest>().QuestIsAccepted*/)
        {
            gameObject.GetComponentInParent<Quest>().QuestIsFinished = true;
            gameObject.SetActive(false);
        }
    }
}
