using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Transform PlayerTrans;
    int chNum = 0;
    // Start is called before the first frame update
    public Vector3 offset;
    public float FollowSpeed;
    public float zoomSpeed;
    public float rotateSpeed;
    

    void Start()
    {
        Invoke("Seach", 0f);
    }

    void Update()
    {
        FollowCharacter();
    }

    private void Seach()
    {
        chNum = SelectLight.characterNum;
        if (chNum == 0)
        {
            target = GameObject.Find("Ekard(Clone)");
            PlayerTrans = target.transform;
        }
        else if(chNum == 1)
        {

        }
    }

    private void FollowCharacter()
    {
        Vector3 CamPos = PlayerTrans.position + offset;
        transform.position = Vector3.Lerp(transform.position, CamPos, FollowSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot.y += Input.GetAxis("Mouse X") * rotateSpeed;
            rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed;
            Quaternion q = Quaternion.Euler(rot);
            q.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);
        }
    }
}
