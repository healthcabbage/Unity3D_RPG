using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour
{
    private static CameraAction instance;
    public static CameraAction Instance => instance;

    public Transform cam;
    Vector3 camPosition_origin;
    public float shake;
    public GameObject shakeaction;
    bool shakecheck = false;

    public CameraAction()
    {
        instance = this;
    }

    public void ShakeTime()
    {
        StartCoroutine("Shake");
        Debug.Log("shake");
    }

    IEnumerator Shake()
    {
        camPosition_origin = cam.position;
        
        yield return new WaitForSeconds(0.1f);

        cam.position = 
            new Vector3(cam.position.x + Random.Range(-shake, shake), cam.position.y + Random.Range(-shake, shake),
            cam.position.z + Random.Range(-shake, shake));
        shakecheck = true;
        actionUI();   
        yield return new WaitForSecondsRealtime(0.1f);

        cam.position = 
            new Vector3(cam.position.x + Random.Range(-shake, shake), cam.position.y + Random.Range(-shake, shake),
            cam.position.z + Random.Range(-shake, shake)); 
        shakecheck = false;
        actionUI();  
        yield return new WaitForSecondsRealtime(0.1f);

        cam.position = camPosition_origin;
    }

    void actionUI()
    {
        if (shakecheck)
        {
            shakeaction.SetActive(true);
        }
        else
        {
            shakeaction.SetActive(false);
        }
    }
}
