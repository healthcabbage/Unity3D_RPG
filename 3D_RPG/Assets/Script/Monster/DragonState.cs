using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonState : MonoBehaviour
{
    public int Maxhp; //최대 hp
    public int hp; //현재 hp

    public GameObject DemegeText;

    public GameObject Dragon;

    public void DeadDragon()
    {
        this.gameObject.GetComponent<ItemDrop>().DropItem();
        Destroy(this.gameObject);
    }
}
