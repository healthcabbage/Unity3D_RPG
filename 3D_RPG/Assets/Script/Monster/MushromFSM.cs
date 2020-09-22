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

    private float chaseDistnace = 9f; //플레이어를 향해 몬스터가 추척을 시작할 거리
    private float attackDistance = 3f; //플레이어가 안쪽으로 들어오게 되면 공격을 시작
    private float reChaseDistance = 3f;
    private float returnDistance = 50f;
    private Vector3 returnPosition;

    private float rotAnglePerSecond = 360f;
    private float moveSpeed = 1.5f;

    private float attackDelay = 2f;
    private float attackTimer = 0;
    public SkinnedMeshRenderer meshRenderer;
    private Color originColor;
    public MonsterSpawn spawn;

    private bool onecheck = false;
    
    void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
        hp = maxhp;
        Invoke("Search", 0.5f);
        spawn = FindObjectOfType<MonsterSpawn>();
    }
    void Start()
    {
        EnemyAni = GetComponent<Animator>();
        ChangeState(State.Idle);
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
                //SFXSoundManager.instance.PlayAttackMush();
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
        }
    }

    void DemageState()
    {
        EnemyAni.SetTrigger("isHit");
        //SFXSoundManager.instance.PlayHitMush();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine("OnHitColor");   
    }

    void DeadState()
    {
        moveSpeed = 0;
        this.GetComponent<BoxCollider>().enabled = false;
        EnemyAni.SetTrigger("isDead");
        //SFXSoundManager.instance.PlayDeadMush();
        Invoke("DeadMush", 2f);
        Invoke("RespawnCheck",2f);
    }

    void TurnToDestination()
    {
        Quaternion lookRotation = Quaternion.LookRotation(player.position - this.transform.position);

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, lookRotation, Time.deltaTime * rotAnglePerSecond);
    }

    void MoveToDestination()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    float GetDistanceFromPlayer()
    {
        float distance = Vector3.Distance(this.transform.position, player.position);
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
        player = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerEnter(Collider weapon)
    {
        if(weapon.gameObject.tag == "Weapon")
        {
            Weapon blade = weapon.GetComponent<Weapon>();
            MushHit(blade.demage);
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

    void RespawnCheck()
    {
        if (onecheck == false)
        {
            spawn.monsterCount--;
            onecheck = true;
            Night.AddCoin(100);
            Night.AddExp(500);
        }
    }
}
