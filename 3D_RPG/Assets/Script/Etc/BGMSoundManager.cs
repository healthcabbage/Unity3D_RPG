using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSoundManager : MonoBehaviour
{
    public static BGMSoundManager instance;
    public AudioClip[] clips;

    public AudioSource source;
    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        source = GetComponent<AudioSource>();
    }

    public void BGM(int _bgmsound)
    {
        source.clip = clips[_bgmsound];
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void SoundOff()
    {
        source.mute = true;
    }

    public void Soundon()
    {
        source.mute = false;
    }

    public void FadeoutMusic()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutMusiccoroutine());
    }

    IEnumerator FadeOutMusiccoroutine()
    {
        for (float i = 1.0f; i >= 0f; i -= 0.01f)
        {
            source.volume = i;
            yield return waitTime;
        }
    }

    public void FadeInMusic(int _bgmsound)
    {
        StopAllCoroutines();
        StartCoroutine(FadeInMusiccoroutine());
    }

    IEnumerator FadeInMusiccoroutine()
    {
        for (float i = 0f; i <= 1f; i += 0.01f)
        {
            source.volume = i;
            yield return waitTime;
        }
    }
}
