using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    Vector3 movement;

    void Start()
    {

    }

    void Update()
    {
        Run();
        Turn();
    }

    void Run()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        movement = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += movement * speed * Time.deltaTime;
    }

    void Turn()
    {
        transform.LookAt(transform.position + movement);
    }
}
