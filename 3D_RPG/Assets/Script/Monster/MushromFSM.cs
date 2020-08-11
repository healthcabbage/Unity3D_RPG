using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushromFSM : MushState
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
    public GameObject Night;

    private float chaseDistnace = 9f; //플레이어를 향해 몬스터가 추척을 시작할 거리
    private float attackDistance = 2.5f; //플레이어가 안쪽으로 들어오게 되면 공격을 시작
    private float reChaseDistance = 3f;
    private float returnDistance = 20f;
    private Vector3 returnPosition;

    private float rotAnglePerSecond = 360f;
    private float moveSpeed = 1.5f;

    private float attackDelay = 2f;
    private float attackTimer = 0;
    public SkinnedMeshRenderer meshRenderer;
    private Color originColor;
    public float StartHealth;

    void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
        hp = maxhp;
    }
    void Start()
    {
        EnemyAni = GetComponent<Animator>();
        ChangeState(State.Idle);
        Mush = GameObject.Find("MushroomMonster");
        
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
            case State.Demage:
                DemageState();
                break;
            case State.Dead:
                DeadState();
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
        returnPosition = Mush.transform.position;
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
        gameObject.GetComponent<BoxCollider>().enabled = true;
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
        Vector3 nowPos = transform.position;
        if (nowPos != returnPosition)
        {
            Mush.transform.position = Vector3.MoveTowards(nowPos, returnPosition, moveSpeed * Time.deltaTime);
            transform.LookAt(returnPosition);      
            EnemyAni.SetTrigger("isRun");
        }
        if (Vector3.Distance(transform.position, returnPosition) <= 0f)
        {
            ChangeState(State.Idle);
            Debug.Log("Return->Idle");
        }
    }

    void DemageState()
    {
        EnemyAni.SetTrigger("isHit");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine("OnHitColor");   
    }

    void DeadState()
    {
        moveSpeed = 0;
        Mush.GetComponent<BoxCollider>().enabled = false;
        EnemyAni.SetTrigger("isDead");
        Invoke("DeadMush", 3f);
        //사망 후 아이템 드롭하기
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

        transform.position = Mush.transform.position;
        hpSlider.value = Mathf.Lerp(hpSlider.value, (float)hp / (float)maxhp, Time.deltaTime * 5f);
    }

    void Search()
    {
        player = GameObject.Find("Ekard(Clone)").transform;
        Night = GameObject.Find("Ekard(Clone)");
    }

    void OnTriggerEnter(Collider weapon)
    {
        if(weapon.gameObject.tag == "Weapon")
        {
            int hit = Night.GetComponent<Night>().atk;
            MushHit(hit);
            DemageText.transform.LookAt(player.position);
            ChangeState(State.Demage);
        }
    }

    private IEnumerator OnHitColor()
    {
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.material.color = originColor;
        yield return new WaitForSeconds(0.2f);
        if (hp > 0)
        {
            ChangeState(State.Attack);
        }
        else if (hp <= 0)
        {
            ChangeState(State.Dead);
        }
        
    }

    

}
