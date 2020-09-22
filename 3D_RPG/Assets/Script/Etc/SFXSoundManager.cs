using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXSoundManager : MonoBehaviour
{
    public static SFXSoundManager instance;

    AudioSource myAudio;

    public AudioClip sndHitMush;
    public AudioClip sndMushAttack;
    public AudioClip sndDropItem;
    public AudioClip sndDeadMush;
    public AudioClip sndPickItem;
    public AudioClip sndBlade;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayHitMush()
    {
        myAudio.PlayOneShot(sndHitMush);
    }

    public void PlayAttackMush()
    {
        myAudio.PlayOneShot(sndMushAttack);
    }

    public void PlayDeadMush()
    {
        myAudio.PlayOneShot(sndDeadMush);
    }

    public void PlayDropItem()
    {
        myAudio.PlayOneShot(sndDropItem);
    }

    public void PlayPickItem()
    {
        myAudio.PlayOneShot(sndPickItem);
    }
}
