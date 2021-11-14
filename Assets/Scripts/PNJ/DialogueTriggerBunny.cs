using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerBunny : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueStart;
    [SerializeField] private Dialogue dialogueEnd;
    [SerializeField] private CinemachineSwitcher cinemachineSwitcher;
    [SerializeField] private string boolTagScene;

    private void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.x < -241f)
        {
            TriggerDialogue(dialogueStart);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            if(false)
            {
                //Dialogue de qu�te finie
                TriggerDialogue(dialogueEnd);
            }
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.Instance.DisplayNextSentence();
        }
        else if(cinemachineSwitcher.isCutSceneOn)
        {
            cinemachineSwitcher.StopScene(boolTagScene);
        }
    }

    private void TriggerDialogue(Dialogue dialogue)
    {
        // Code pour trigger la boite de dialogue avec les param�tres
        cinemachineSwitcher.StartScene(boolTagScene);
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
