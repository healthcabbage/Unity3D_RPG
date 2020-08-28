using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    Dictionary <int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
    }

    void GenerateDate()
    {
        //questList.Add(100, new QuestData(""));
    }
}
