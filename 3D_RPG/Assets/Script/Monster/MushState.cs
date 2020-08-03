using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushState : MonoBehaviour
{
    public float StartHealth;
    public int hp;
    public int atk;
    public GameObject DemageText;
    public GameObject TextPos;
    public GameObject HealthBar;
    public GameObject Player;

    public void MushHit(int Demage)
    {
        if (hp > 0)
        {
            GameObject dmgText = Instantiate(DemageText, TextPos.transform.position, Quaternion.identity);
            dmgText.GetComponent<Text>().text = Demage.ToString();
            hp -= Demage;
            //HealthBar.GetComponent<Image>().fillAmount = hp / StartHealth;   
            Destroy(dmgText, 1f);
        }       
    }
}
