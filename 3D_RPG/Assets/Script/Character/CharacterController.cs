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
        Run();
        Attack();
    }

    void Run()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        movement = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += movement * speed * Time.deltaTime;

        transform.LookAt(transform.position + movement);

        anim.SetBool("isRun", movement != Vector3.zero);
    }

    void Attack()
    {
        if(Input.GetMouseButton(0))
        {
            Debug.Log("확인");
            anim.SetBool("isAttack", true);
            Invoke("Idle", 1f);
        }
    }

    void Idle()
    {
        anim.SetBool("isAttack", false);
    }
}
