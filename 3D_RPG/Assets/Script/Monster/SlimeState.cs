using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeState : MonoBehaviour
{
    public int maxhp;
    public int hp;
    public int mp = 50;
    public int atk;
    public GameObject DemageText;
    public Transform hudPos;
    public GameObject HealthBar;
    public GameObject HitEffect;
    public Transform HitPos;
    public GameObject Slime;
    public Slider hpSlider;

    public void SlimeHit(int Demage)
    {
        if (hp > 0)
        {
            GameObject hudText = Instantiate(DemageText);
            hudText.GetComponent<DamageText>().damage = Demage;
            hudText.transform.position = hudPos.position;
            hudText.transform.rotation = Quaternion.Euler(0, -90, 0);

            CreateHitEffect();

            hp -= Demage;
        }
    }

    void CreateHitEffect()
    {
        Instantiate(HitEffect);
        HitEffect.transform.position = HitPos.position;
    }

    public void DeadSlime()
    {
        this.gameObject.GetComponent<ItemDrop>().DropItem();
        Destroy(this.gameObject);
        Destroy(hpSlider);
    }
}
