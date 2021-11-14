using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerBunny : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueStart;
    [SerializeField] private Dialogue dialogueEnd;
    [SerializeField] private CinemachineSwitcher cinemachineSwitcher;
    [SerializeField] private string boolTagScene;

    [SerializeField] private GameObject lapineTriste;
    [SerializeField] private GameObject lapineNormal;
    [SerializeField] private GameObject lapineKiss;

    [SerializeField] private GameObject credits;

    private int Ecount;

    private void Start()
    {
        Ecount = 0;
    }
    void Update()
    {
        if (transform.position.x < -240f)
        {
            if ( Ecount == 0 )
            {
                TriggerDialogue(dialogueStart);
                Ecount = 1;
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                Ecount ++;
                DialogueManager.Instance.DisplayNextSentence();
                if (Ecount == 3)
                {
                    lapineTriste.SetActive(false);
                    lapineNormal.SetActive(true);
                }
                if (Ecount == 6)
                {
                    lapineNormal.SetActive(false);
                    lapineKiss.SetActive(true);
                    credits.SetActive(true);
                }
            }

        }


    }

    private void TriggerDialogue(Dialogue dialogue)
    {
        // Code pour trigger la boite de dialogue avec les param�tres
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
