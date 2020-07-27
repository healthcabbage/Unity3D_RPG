using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    Vector3 movement;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        movement = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += movement * speed * Time.deltaTime;

        transform.LookAt(transform.position + movement);

        anim.SetBool("isRun", movement != Vector3.zero);

        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isAttack");
        }
    }
}
