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

        cam.position = 
            new Vector3(cam.position.x + Random.Range(-shake, shake), cam.position.y + Random.Range(-shake, shake),
            cam.position.z + Random.Range(-shake, shake));   
        yield return new WaitForSecondsRealtime(0.05f);

        cam.position = 
            new Vector3(cam.position.x + Random.Range(-shake, shake), cam.position.y + Random.Range(-shake, shake),
            cam.position.z + Random.Range(-shake, shake));   
        yield return new WaitForSecondsRealtime(0.05f);

        cam.position = camPosition_origin;
    }
}
