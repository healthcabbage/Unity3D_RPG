using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Transform PlayerTrans;
    public Vector3 offset;
    public Vector3 CameraOffset;

    public Transform Cameratrans;

    public float FollowSpeed;

    public float zoomSpeed;

    float X_wheel = 15f;
    float Y_wheel = 10f;

    void Start()
    {
        Invoke("Seach", 0f);
    }

    void Update()
    {
        FollowCharacter();
        Zoom();
    }

    private void Seach()
    {
        target = GameObject.Find("Ekard(Clone)");
        PlayerTrans = target.transform;
    }

    void FollowCharacter()
    {
        CameraOffset = PlayerTrans.position + offset;

        transform.position = Vector3.Lerp(transform.position, CameraOffset, FollowSpeed * Time.deltaTime);
    }

    void Zoom()
    {
        X_wheel -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Y_wheel -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (X_wheel <= 15)
            X_wheel = 15;
        if (X_wheel >= 30)
            X_wheel = 30;

        if (Y_wheel <= 10)
            Y_wheel = 10;
        if (Y_wheel >= 25)
            Y_wheel = 25;

        offset = new Vector3(X_wheel, Y_wheel, 0);
    }

}
