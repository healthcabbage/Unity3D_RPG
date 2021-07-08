using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFSM : SlimeState
{
    //원거리 공격을 하는 슬라임
    public enum State
    {
        Idle,
        Chase,
        Attack,
        Return,
        Demage,
        Manaburn,
        Dead
    }

    public State currentState = State.Idle;
    Animator SlimeAni;
    public Transform player;

    private float chaseDistance = 9f;
    private float attackDistance = 6f;
    private float returnDistance = 50f;
    private Vector3 returnPosition;

    private float rotAnglePerSecond = 300f;
    private float moveSpeed = 1.5f;

    private float attackDelay = 2f;
    private float attackTimer = 0f;
    private float manaburnDelay = 3f;
    private float manaburnTimer = 0f;
    public SkinnedMeshRenderer meshRenderer;
    private Color originColor;
    public MonsterSpawn spawn;

    public GameObject bullet; //발사체

    private bool onecheck = false;

    void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
        hp = maxhp;
        mp = maxmp;
        Invoke("Search", 0.5f);
        spawn = FindObjectOfType<MonsterSpawn>();
    }

    void Start()
    {
        SlimeAni = GetComponent<Animator>();
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
                DemegeState();
                break;
            case State.Manaburn:
                ManaburnState();
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
        returnPosition = Slime.transform.position;
        if (GetDistanceFromPlayer() < chaseDistance)
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
            SlimeAni.SetTrigger("isRun");
            TurnToDestination();
            MoveToDestination();
        }
    }

    void AttackState()
    {
        if (GetDistanceFromPlayer() > chaseDistance)
        {
            ChangeState(State.Chase);
        }
        else
        {
            if (attackTimer > attackDelay)
            {
                if (mp > 0)
                {
                    transform.LookAt(player.position);
                    StartCoroutine("OnAttack");
                    attackTimer = 0f;   
                }
                else
                {
                    attackTimer = 0f;
                    ChangeState(State.Manaburn);
                }
            }
            attackTimer += Time.deltaTime;
        }
    }

    void ReturnState()
    {
        Vector3 nowPos = transform.position;
        if (nowPos != returnPosition)
        {
            Slime.transform.position = Vector3.MoveTowards(nowPos, returnPosition, moveSpeed * Time.deltaTime);
            transform.LookAt(returnPosition);
            SlimeAni.SetTrigger("isRun");
        }
        if (Vector3.Distance(transform.position, returnPosition) <= 0f)
        {
            ChangeState(State.Idle);
        }
    }

    void DemegeState()
    {
        SlimeAni.SetTrigger("isHit");
        StartCoroutine("OnHitColor");
    }

    void ManaburnState()
    {
        if (mp < 50)
        {
            SlimeAni.SetTrigger("isNoAttack");
            Invoke("Reset", 4f);
        }
    }

    void DeadState()
    {
        moveSpeed = 0;
        this.GetComponent<BoxCollider>().enabled = false;
        SlimeAni.SetTrigger("isDead");
        Invoke("DeadSlime", 2f);
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

        transform.position = Slime.transform.position;
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
            SlimeHit(blade.demage);
            CreateHitEffect();
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

    void Reset()
    {
        mp = maxmp;
        attackTimer = 0f;
        ChangeState(State.Attack);
    }

    private IEnumerator OnAttack()
    {
        SlimeAni.SetTrigger("isAttack");
        yield return new WaitForSeconds(0.3f);
        GameObject instantbullet = Instantiate(bullet, HitPos.transform.position, transform.rotation);
        Rigidbody rigidBullet = instantbullet.GetComponent<Rigidbody>();
        rigidBullet.velocity = transform.forward * 20;
        mp -= 10;
    }
}
