using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "New Skill/skill")]
public class Skill : ScriptableObject
{
    public Skilltype skilltype;
    public string skillname; //스킬 이름
    public int Mana; //마나 소모
    public int Damage; //스킬이 주는 데미지
    public Sprite Image; //스킬 이미지
    public int Upgradestate; //업그레이드 시켜줄 스탯수치

    public enum Skilltype //스킬 타입
    {
        Atk,
        Buff,
        Hill
    }
}
