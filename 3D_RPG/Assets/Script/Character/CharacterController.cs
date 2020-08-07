using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;

    bool fDown;
    bool idown;

    bool isFireReady;
    public Weapon weapon;
    Vector3 movement;
    Animator anim;
    float fireDelay;
    public InventoryUI inventory;

    private void Awake()
    {

    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    [System.Obsolete]
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Attack();
        Inventory();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        fDown = Input.GetButtonDown("Attack");
        idown = Input.GetButtonDown("Inven");
    }

    void Move()
    {
        movement = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += movement * speed * Time.deltaTime;
        anim.SetBool("isRun", movement != Vector3.zero);
        if (fDown)
        {
            
        }
    }

    void Turn()
    {
        transform.LookAt(transform.position + movement);      
    }

    void Attack()
    {
        if (fDown)
        {   
            movement = Vector3.zero;
            weapon.Use();
            anim.SetTrigger("isAttack");
        }
    }

    void Inventory()
    {
        if (idown)
        {
            inventory.Open();
        }
    }
}
