using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Night : MonoBehaviour
{
    //기사 캐릭터 수치, 
    public int Maxhp;
    public int hp;
    public Slider hpSlider;
    public Text hptext;

    public int Maxmp;
    public int mp;
    public Slider mpSlider;

    public int MaxExp;
    public static int Exp = 0;
    public Slider expSlider;

    public int atk = 10;
    Animator night_ani;

    bool deadcheck = false;
    bool hprecover = false;
    bool mprecover = false;
    public static int Coin = 1000; //소유 금액
    public Text CoinText;

    private int Level = 1;
    private int MaxLevel = 10;
    public Text LevelText;

    void Awake()
    {
        night_ani = GetComponent<Animator>();
        hp = Maxhp;
        mp = Maxmp;
        LevelText.text = "LV : " + Level.ToString();
    }
    void Update()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, (float)hp / (float)Maxhp, Time.deltaTime * 5f);
        mpSlider.value = Mathf.Lerp(mpSlider.value, (float)mp / (float)Maxmp, Time.deltaTime * 5f);
        expSlider.value = Mathf.Lerp(expSlider.value, (float)Exp / (float)MaxExp, Time.deltaTime * 5f);
        CoinText.text = Coin.ToString();
        LevelCheck();
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
            MushState Mush = Enemy.GetComponentInParent<MushState>();
            HitDemage(Mush.atk);
        }
        else if (Enemy.gameObject.tag == "Enemybullet")
        {
            SlimeState Slime = Enemy.GetComponentInParent<SlimeState>();
            HitDemage(Slime.atk);
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

    public static void AddCoin(int _coin)
    {
        Coin += _coin;
    }

    public static void AddExp(int _exp)
    {
        Exp += _exp;
    }

    void LevelCheck()
    {
        if (Level != MaxLevel)
        {           
            if (Exp == MaxExp)
            {
                Level++;
                LevelText.text = "LV : " + Level.ToString();
                Exp = 0;
            }
        }
    }

    void HpCheck()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, (float)hp / (float)Maxhp, Time.deltaTime * 5f);
    }
}
