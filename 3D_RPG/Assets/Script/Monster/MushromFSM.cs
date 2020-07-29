﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushromFSM : MonoBehaviour
{
    public enum State
    {
        Idle,
        Chase,
        Attack,
        Return,
        Demage,
        Dead
    }
    public State currentState = State.Idle;
    Animator EnemyAni; //몬스터 애니메이터
    public Transform player; //플레이어 거리 가져오기
    public GameObject Mush;

    private float chaseDistnace = 9f; //플레이어를 향해 몬스터가 추척을 시작할 거리
    private float attackDistance = 2.5f; //플레이어가 안쪽으로 들어오게 되면 공격을 시작
    private float reChaseDistance = 3f;
    private float returnDistance = 20f;
    private Vector3 returnPosition;

    private float rotAnglePerSecond = 360f;
    private float moveSpeed = 1.5f;

    private float attackDelay = 2f;
    private float attackTimer = 0;

    void Start()
    {
        EnemyAni = GetComponent<Animator>();
        ChangeState(State.Idle);
        Mush = GameObject.Find("MushroomMonster");
        returnPosition = Mush.transform.position;
        
        Invoke("Search", 0f);
    }

    void UpdateState()
    {
        switch(currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Chase:
                ChaseState();
                break;
            case State.Attack:
                AttackState();
                break;
            case State.Return:
                ReturnState();
                break;
        }
    }

    public void ChangeState(State newState)
    {
        if (currentState == newState)
        {
            return;
        }
        currentState = newState;
    }

    void IdleState()
    {
        if (GetDistanceFromPlayer() < chaseDistnace)
        {
            ChangeState(State.Chase);
        }
    }

    void ChaseState()
    {
        if (GetDistanceFromPlayer() < attackDistance)
        {
            ChangeState(State.Attack);
        }
        else if (GetDistanceFromPlayer() > returnDistance)
        {
            ChangeState(State.Return);
        }
        else
        {
            EnemyAni.SetTrigger("isRun");
            TurnToDestination();
            MoveToDestination();
        }
    }

    void AttackState()
    {
        if (GetDistanceFromPlayer() > reChaseDistance)
        {
            ChangeState(State.Chase);
        }
        else
        {
            if (attackTimer > attackDelay)
            {
                transform.LookAt(player.position);
                EnemyAni.SetTrigger("isAttack");

                attackTimer = 0f;
            }

            attackTimer += Time.deltaTime;
        }
    }

    void ReturnState()
    {
        Mush.transform.position = Vector3.MoveTowards(transform.position, returnPosition, moveSpeed * Time.deltaTime);
        Quaternion lookRotation = Quaternion.LookRotation(returnPosition);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,rotAnglePerSecond * Time.deltaTime);
        
        EnemyAni.SetTrigger("isRun");
        if (transform.position == returnPosition)
        {
            ChangeState(State.Idle);
        }
    }

    void TurnToDestination()
    {
        Quaternion lookRotation = Quaternion.LookRotation(player.position - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotAnglePerSecond);
    }

    void MoveToDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    float GetDistanceFromPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance;
    }

    void Update()
    {
        UpdateState();
    }

    void Search()
    {
        player = GameObject.Find("Ekard(Clone)").transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
        }
    }
}
