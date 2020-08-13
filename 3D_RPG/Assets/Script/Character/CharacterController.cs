﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;

    bool fDown;
    bool idown;

    bool isAttackReady = true; //다시 공격준비 완료
    bool ComboReady = false;
    public Weapon weapon;
    Vector3 movement;
    Animator anim;
    public InventoryUI inventory;

    float attackDelay; //공격 딜레이
    float ComboTime;
    float ComboDelay;

    private void Awake()
    {
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

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
        idown = Input.GetButtonDown("Inventory");
    }

    void Move()
    {
        movement = new Vector3(hAxis, 0, vAxis).normalized;

        if (!isAttackReady || ComboReady)
            movement = Vector3.zero;
        

        transform.position += movement * speed * Time.deltaTime;
        anim.SetBool("isRun", movement != Vector3.zero);
    }

    void Turn()
    {
        transform.LookAt(transform.position + movement);      
    }

    void Attack()
    {
        attackDelay += Time.deltaTime;
        isAttackReady = weapon.rate < attackDelay;
        //공격을 진행할때 딜레이를 줘야된다.
        if (fDown && isAttackReady)
        {
            weapon.Use();
            anim.SetTrigger("isAttack");
            attackDelay = 0;
            ComboReady = true;
            ComboTime += Time.deltaTime;
        }

        if (ComboTime > 2f)
        {
            ComboReady = false;
        }
        if(fDown && ComboReady)
        {
            anim.SetTrigger("isAttack");
            weapon.Use();
            Invoke("UnCombo", 1f);
        }

    }

    void Inventory()
    {
        if (idown)
        {
            inventory.Open();
        }
    }

    void UnCombo()
    {
        ComboReady = false;
    }
}
