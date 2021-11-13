using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutScene : MonoBehaviour
{

    [SerializeField] private Animator animator;
    public bool isCutSceneOn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
        }
    }
    public void StartCutScene()
    {
        animator.SetBool("cutScene1", true);
        isCutSceneOn = true;
    }

    public void StopCutScene()
    {
        animator.SetBool("cutScene1", false);
        isCutSceneOn = false;
    }
}
