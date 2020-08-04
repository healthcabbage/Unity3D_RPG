using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushState : MonoBehaviour
{
    public int hp;
    public int atk;
    public GameObject DemageText;
    public Transform hudPos;
    public GameObject HealthBar;
    public GameObject HitEffect;
    public Transform HitPos;

    public void MushHit(int Demage)
    {
        if (hp > 0)
        {
            GameObject hudText = Instantiate(DemageText);
            hudText.GetComponent<DamageText>().damage = Demage;
            hudText.transform.position = hudPos.position;
            hudText.transform.rotation = Quaternion.Euler(0, -90, 0);

            CreateHitEffect();

            hp -= Demage;
            //HealthBar.GetComponent<Image>().fillAmount = hp / StartHealth;   
        }       
    }

    void CreateHitEffect()
    {
        Instantiate(HitEffect);
        HitEffect.transform.position = HitPos.position;
    }
}
