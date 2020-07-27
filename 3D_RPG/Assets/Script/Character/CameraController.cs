using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    public Transform target2;

    int chNum = 0;
    // Start is called before the first frame update
    public Vector3 offset;
    public float FollowSpeed;

    void Start()
    {
        Invoke("Seach", 0f);
    }

    void Update()
    {
        Vector3 CamPos = target2.position + offset;

        transform.position = Vector3.Lerp(transform.position, CamPos, FollowSpeed * Time.deltaTime);
    }

    void Seach()
    {
        chNum = SelectLight.characterNum;
        if (chNum == 0)
        {
            target = GameObject.Find("Ekard(Clone)");
            target2 = target.transform;
        }
        else if(chNum == 1)
        {

        }
    }
}
