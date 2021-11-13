using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private CinemachineSwitcher cinemachineSwitcher;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cinemachineSwitcher.StartFixeScene("LionQuestScene");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cinemachineSwitcher.StopFixeScene("LionQuestScene");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cinemachineSwitcher = GetComponentInParent<CinemachineSwitcher>();
    }
}
