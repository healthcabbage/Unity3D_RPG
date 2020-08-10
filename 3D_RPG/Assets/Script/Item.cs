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
    public ItemType itemType;
    public string itemName;
    public GameObject itemPrefab;

    public bool Use()
    {
        return false;
    }
    
}
