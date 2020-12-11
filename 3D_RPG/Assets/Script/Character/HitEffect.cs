using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    //public

    bool stopping = false;
    public float stopTime;
    public float slowTime;

    public CameraAction shake;

    public void TimeStop()
    {
        if(!stopping)
        {
            stopping = true;
            Time.timeScale = 0;

            StartCoroutine("Stop");
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSecondsRealtime(stopTime);

        Time.timeScale = 1;
        stopping = false;
    }
}
