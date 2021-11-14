using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavingFeather : MonoBehaviour
{
    [SerializeField] private float beginAngle;
    [SerializeField] private float endAngle;
    [SerializeField] private float wavingPeriod;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;

    private float fadingSpeed;
    private new SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        var color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        var t = 2 * Time.time / wavingPeriod;
        t -= 2 * Mathf.Floor(t / 2);
        if (t >= 1) t = 2 - t;

        transform.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(beginAngle, endAngle, t));

        var color = spriteRenderer.color;
        color.a = Mathf.Clamp01(color.a + fadingSpeed * Time.deltaTime);
        if (color.a == 0 || color.a == 1) fadingSpeed = 0;
        spriteRenderer.color = color;
    }

    public void FadeIn()
    {
        fadingSpeed = 1.0f / fadeInTime;
    }

    public void FadeOut()
    {
        fadingSpeed = -1.0f / fadeOutTime;
    }
}
