using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest01 : MonoBehaviour
{
    [SerializeField] private int questIndex;
    [SerializeField] private GameObject toDestroy;
    public void EndQuest()
    {
        if (questIndex == 0)
        {
            PlayerMovement.CanClimb = true;
            Debug.Log("EndFirstQuest");
        }
        else if (questIndex == 1)
        {
            PlayerMovement.CanGlide = true;
            Debug.Log("EndSecondQuest");
        }
        else if (questIndex == 2)
        {
            toDestroy.SetActive(false);
            Debug.Log("EndThirdQuest");
        }
    }
}
