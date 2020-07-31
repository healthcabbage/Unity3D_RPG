using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushState : MonoBehaviour
{
    public int hp;
    public int atk;

    public void MushHit(int Demage)
    {
        if (hp > 0)
        {
            hp -= Demage;   
        }       
    }
}
