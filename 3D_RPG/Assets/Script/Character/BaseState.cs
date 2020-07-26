using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{
    protected enum Charactertype
    {
        night,
        wizard
    }

    protected enum Enemytype
    {
        MushEnemy,
        SlimeEnemy,
        DragonEnemy
    }

    int hp;
    int mp;
    
}
