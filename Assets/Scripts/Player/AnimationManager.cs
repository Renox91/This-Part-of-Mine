using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;
    [SerializeField] private Sprite jumpSprite;
    [SerializeField] private Sprite walkSprite;
    [SerializeField] private Sprite idleSprite;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void SetJump(bool value)
    {
        //spriteRenderer.sprite = jumpSprite;
        animator.SetBool("Jump", value);
    }


    public void SetSpeed(float value)
    {
        animator.SetFloat("Speed", value);
    }
}
