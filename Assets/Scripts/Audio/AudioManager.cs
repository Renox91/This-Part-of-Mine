using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource mySource;
    [SerializeField] private AudioSource secondarySource;
    private float initialVolume;
    [SerializeField] float fadeTime;
    private void Awake()
    {
        mySource = GetComponent<AudioSource>();
        initialVolume = mySource.volume;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchMusic();
        }
    }
    public void SwitchMusic()
    {
        secondarySource.Play();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        for (float ft = 0; ft <= fadeTime; ft += Time.deltaTime)
        {
            mySource.volume = initialVolume * (1 - ft/ fadeTime);
            secondarySource.volume = ft * initialVolume / fadeTime;
            yield return null;
        }
        mySource.Stop();
    }
}
