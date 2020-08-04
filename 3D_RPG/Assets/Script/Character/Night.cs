using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{
    public int hp = 500;
    public int mp = 300;
    public int atk = 10;
    Animator night_ani;
    public GameObject Mush;

    void Awake()
    {
        night_ani = GetComponent<Animator>();
        Mush = GameObject.Find("MushroomMonster");
    }

    public void Run(Vector3 check)
    {
        
    }

    public void HitDemage(int Demage)
    {
        if (hp > 0)
        {
            hp -= Demage;
        }
    }

    void OnTriggerEnter(Collider Enemy)
    {
        if (Enemy.gameObject.tag == "Mushroom")
        {
            Mush.GetComponent<MushromFSM>().MushHit(atk);
            Debug.Log("Demage");
        }
    }
}
