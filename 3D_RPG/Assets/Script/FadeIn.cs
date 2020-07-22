using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float FadeTime;
    public Image fadeImg;
    float start;
    float end;
    float time = 0f;
    public bool isPlaying = false;
    public bool fadeselect;

    public void Awake()
    {
        fadeImg = GetComponent<Image>();
        if (fadeselect != false)
        {
            InStartFadeAnim();
        }
        else
        {
            OutStartFadeAnim();
        }

    }

    public void InStartFadeAnim()
    {
        if (isPlaying == true) //중복방지
        {
            return;
        }

        start = 1f;
        end = 0;

        StartCoroutine("fadeInplay");
    }

    IEnumerator fadeInplay()
    {
        isPlaying = true;

        Color fadecolor = fadeImg.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(start, end, time);

        while (fadecolor.a > 0f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeImg.color = fadecolor;
            yield return null;
        }

        isPlaying = false;
    }

    public void OutStartFadeAnim()
    {
        if (isPlaying == true)
        {
            return;
        }

        start = 0f;
        end = 1f;
        StartCoroutine("fadeoutplay");
    }

    IEnumerator fadeoutplay()
    {
        isPlaying = true;

        Color fadecolor = fadeImg.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(start, end, time);

        while (fadecolor.a < 255f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeImg.color = fadecolor;
            yield return null;
        }

        isPlaying = false;
    }
}
