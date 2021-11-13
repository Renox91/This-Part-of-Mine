using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    private Animator animator;
    public bool isCutSceneOn;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartScene(string boolTag)
    {
        animator.SetBool(boolTag, true);
        isCutSceneOn = true;
    }

    public void StopScene(string boolTag)
    {
        animator.SetBool(boolTag, false);
        isCutSceneOn = false;
    }

    public void StartFixeScene(string boolTag)
    {
        animator.SetBool(boolTag, true);
    }

    public void StopFixeScene(string boolTag)
    {
        animator.SetBool(boolTag, false);
    }
}
