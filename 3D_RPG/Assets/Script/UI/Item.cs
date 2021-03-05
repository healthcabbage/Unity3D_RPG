using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public ItemType itemType; //아이템 타입
    public string itemName; //이름
    public Sprite itemImage; //아이템 이미지
        
    public enum ItemType
    {
        Consumables, //포션
        Gem, //몬스터 드랍 젬
        Etc
    }  
}
