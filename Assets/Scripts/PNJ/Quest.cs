using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private bool questIsAccepted = false;
    public bool QuestIsAccepted
    {
        get { return questIsAccepted; }
        set { questIsAccepted = value; }
    }

    [SerializeField] private bool questIsFinished = false;
    public bool QuestIsFinished
    {
        get { return questIsFinished; }
        set { questIsFinished = value; }
    }
}
