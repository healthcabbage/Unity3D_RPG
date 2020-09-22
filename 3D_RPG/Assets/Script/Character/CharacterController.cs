using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;

    bool fDown;
    bool idown;
    bool zdown;
    bool spacedown;

    bool isAttackReady = true; //다시 공격준비 완료
    bool ComboReady = false;
    public Weapon weapon;
    Vector3 movement;
    Animator anim;
    public InventoryUI inventory;

    float attackDelay; //공격 딜레이
    float ComboTime;
    float ComboDelay;

    public Text actionText;

    public Text actionText2;

    [SerializeField]
    private Inventory inven;
    public GameManager manager;
    GameObject scanObject;
    float MaxDistance = 10f;
    public GameObject Point;
    GameObject Item;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        actionText.enabled = false;
        actionText2.enabled = false;
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Attack();
        Inventory();
        RayhitCheck();
        Action();
    }

    void GetInput()
    {
        hAxis = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        vAxis = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        fDown = manager.isAction ? false : Input.GetButtonDown("Attack");
        idown = manager.isAction ? false : Input.GetButtonDown("Inventory");
        zdown = manager.isAction ? false : Input.GetButtonDown("PickUp");
        spacedown = Input.GetButtonDown("Space");
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
        if (!inventory.activeinven)
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

    void Action()
    {
        if (spacedown && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }

    void RayhitCheck()
    {
        RaycastHit rayHit;

        Debug.DrawRay(Point.transform.position, transform.forward * 8, Color.red);

        if (Physics.Raycast(Point.transform.position, this.transform.forward, out rayHit, 8f, LayerMask.GetMask("Object")))
        {
            Debug.Log(rayHit.transform.gameObject.name);
            scanObject = rayHit.collider.gameObject;
            actionText2.enabled = true;
        }
        else
        {
            actionText2.enabled = false;
            scanObject = null;
        }

        if (Physics.Raycast(Point.transform.position, this.transform.forward, out rayHit, 2f, LayerMask.GetMask("Item")))
        {
            Item = rayHit.collider.gameObject;
            actionText.enabled = true;
            if (zdown)
            {
                Debug.Log("줍기");
                SFXSoundManager.instance.PlayPickItem();
                Debug.Log(Item.GetComponent<ItemPickUp>().item.itemName);
                inven.AcquireItem(Item.GetComponent<ItemPickUp>().item);
                Destroy(Item.gameObject);
                actionText.enabled = false;
            }
            
        }
        else
        {
            actionText.enabled = false;
            Item = null;
        }
    }
}
