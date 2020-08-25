using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{
    public string itemName;
    public string[] part;
    public int[] num;
}

public class ItemEffectDatabase : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;
    [SerializeField]
    public Night nightstate;

    private const string Hp = "Hp", Mp = "Mp";
    public void UseItem(Item _item)
    {
        if(_item.itemType == Item.ItemType.Consumables)
        {
            for (int x = 0; x < itemEffects.Length; x++)
            {
                if(itemEffects[x].itemName == _item.itemName)
                {
                    for (int y = 0; y < itemEffects[x].part.Length; y++)
                    {
                        switch (itemEffects[x].part[y])
                        {
                            case Hp:
                                nightstate.RecoveryHp(itemEffects[x].num[y]);
                                break;
                            case Mp:
                                nightstate.RecoveryMp(itemEffects[x].num[y]);
                                break;
                            default:
                                break;
                        }   
                        Debug.Log(_item.itemName + "을 사용했습니다");
                    }
                    return;
                }   
            }
            Debug.Log("일치하는 itemName이 없습니다.");
        }
    }
}
