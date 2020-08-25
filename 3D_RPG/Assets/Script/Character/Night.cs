using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Night : MonoBehaviour
{
    //기사 캐릭터 수치, 
    public int Maxhp;
    public int hp;
    public int Maxmp;
    public int mp;
    public int atk = 10;
    Animator night_ani;
    public MushState Mush;
    public Slider hpSlider;
    public Slider mpSlider;
    bool deadcheck = false;
    bool hprecover = false;
    bool mprecover = false;
    public Text hptext;

    void Awake()
    {
        night_ani = GetComponent<Animator>();
        hp = Maxhp;
        mp = Maxmp;
    }
    void Update()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, (float)hp / (float)Maxhp, Time.deltaTime * 5f);
        mpSlider.value = Mathf.Lerp(mpSlider.value, (float)mp / (float)Maxmp, Time.deltaTime * 5f);
    }

    public void HitDemage(int Demage)
    {
        if (hp > 0)
        {
            Debug.Log(hp);
            hp -= Demage;
        }

        if (hp <= 0 && deadcheck)
        {
            Dead();
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

    void Dead()
    {
        night_ani.SetTrigger("isDead");
        deadcheck = false;
    }
    
    public void RecoveryHp(int recovery)
    {
        if (hp < Maxhp)
        {
            hprecover = true;
            hp += recovery;
        }
        else
            Debug.Log("Hp가 가득차 사용할 수 없습니다.");
            hprecover = false;
    }

    public void RecoveryMp(int re_mp)
    {
        if (mp < Maxmp)
            mp += re_mp;
        else
            Debug.Log("Mp가 가득차 사용할 수 없습니다.");
    }
}
