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

    float X_wheel;
    float Y_wheel;

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

        if (X_wheel <= 5)
            X_wheel = 5;
        if (X_wheel >= 15)
            X_wheel = 15;

        if (Y_wheel <= 5)
            Y_wheel = 5;
        if (Y_wheel >= 10)
            Y_wheel = 10;

        offset = new Vector3(X_wheel, Y_wheel, 0);
    }
}
