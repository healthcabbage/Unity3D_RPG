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
    private bool atk = false;
    private bool walk = false;

    private void Awake()
    {
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    [System.Obsolete]
    void Update()
    {
        if (!atk)
        {
            hAxis = Input.GetAxisRaw("Horizontal");
            vAxis = Input.GetAxisRaw("Vertical");

            movement = new Vector3(hAxis, 0, vAxis).normalized;

            transform.position += movement * speed * Time.deltaTime;

            transform.LookAt(transform.position + movement);

            anim.SetBool("isRun", movement != Vector3.zero);

            walk = true;

            if (movement == Vector3.zero)
            {
                walk = false;
            }
        }
        if (walk != true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("isAttack");
                atk = true;
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.IDLE"))
        {
           atk = false;
        }
    }
}
