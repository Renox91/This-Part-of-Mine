using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (FindObjectOfType<PlayerMovement>().transform.position.x < -240f)
        {
            if ( Ecount == 0 )
            {
                TriggerDialogue(dialogueStart);
                Ecount = 1;
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.Instance.DisplayNextSentence();
            }
        }
    }
    public void SadLapine()
    {
        lapineTriste.SetActive(false);
        lapineNormal.SetActive(true);
    }

    public void KissLapine()
    {
        lapineNormal.SetActive(false);
        lapineKiss.SetActive(true);
        credits.SetActive(true);
        Invoke("EndGame", 5f);
    }

    public void EndGame()
    {
        //SceneManager.LoadScene(2);
    }
    private void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<AudioManager>().SwitchMusic();
        DialogueManager.Instance.EndMode = true;
        // Code pour trigger la boite de dialogue avec les param�tres
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
