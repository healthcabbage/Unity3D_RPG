using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Night : MonoBehaviour
{
    //기사 캐릭터 수치, 
    public int Maxhp;
    public int hp = 500;
    public int mp = 300;
    public int atk = 10;
    Animator night_ani;
    public MushState Mush;
    public Slider hpSlider;
    public Slider mpSlider;
    bool deadcheck = false;

    void Awake()
    {
        night_ani = GetComponent<Animator>();
        hp = Maxhp;
    }
    void Update()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, (float)hp / (float)Maxhp, Time.deltaTime * 5f);
    }

    void LateUpdate()
    {
        if (!deadcheck)
        {
            if (hp <= 0)
            {
                StartCoroutine("DeadPlayer");
                deadcheck = true;
            }
        }
    }
    public void HitDemage(int Demage)
    {
        if (hp > 0)
        {
            Debug.Log(hp);
            hp -= Demage;
        }
    }

    void OnTriggerEnter(Collider Enemy)
    {
        if (Enemy.gameObject.tag == "Mushroom")
        {
            int hit = Mush.atk;
            HitDemage(hit);
        }
    }

    IEnumerator DeadPlayer()
    {
        night_ani.SetTrigger("isDead");
        yield return null;
    }
}
