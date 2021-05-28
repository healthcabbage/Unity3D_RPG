using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFSM : DragonState
{
    public enum State
    {
        IDLE,
        Chase,
        Dead   
    }

    public State currentState = State.Dead;
    Animator EnemyAni;
    public Transform player;

    void Awake()
    {

    }

    void Start()
    {
        
    }

    void UpdateState()
    {
        switch(currentState)
        {
            case State.IDLE:
                break;
            case State.Chase:
                break;
            case State.Dead:
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
        //플레이어가 일정 거리에 들어오지 않으면 대기 자세
    }

    void ChaseState()
    {

    }

    void DeadState()
    {
        Invoke("DeadDragon", 2f);
    }
    
}
