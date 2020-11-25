using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushState : MonoBehaviour
{
    public int maxhp;
    public int hp;
    public int atk;
    public GameObject DemageText;
    public Transform hudPos;
    public GameObject HealthBar;
    public GameObject HitEffect;
    public Transform HitPos;
    public GameObject Mush;
    public Slider hpSlider;

    public void MushHit(int Demage)
    {
        if (hp > 0)
        {
            GameObject hudText = Instantiate(DemageText);
            hudText.GetComponent<DamageText>().damage = Demage;
            hudText.transform.position = hudPos.position;
            hudText.transform.rotation = Quaternion.Euler(0, -90, 0);
            hp -= Demage;
        }       
    }

    public void CreateHitEffect()
    {
        HitEffect.transform.position = HitPos.position;
        Instantiate(HitEffect, HitEffect.transform.position, Quaternion.identity);
    }

    public void DeadMush()
    {
        this.gameObject.GetComponent<ItemDrop>().DropItem();
        SFXSoundManager.instance.PlayItem(0);
        Destroy(this.gameObject);
        Destroy(hpSlider);
    }
}
