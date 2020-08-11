using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumables,
    Coin,
    Etc
}

[System.Serializable]
public class Item
{
    public ItemType itemType; //아이템 타입
    public string itemName; //이름
    public int itemvalue; //아이템 갯수
    public int itemPrice; //아이템 가격
    public Sprite itemImage;

    public bool Use()
    {
        return false;
    }
    
}
