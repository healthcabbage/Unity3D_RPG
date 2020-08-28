using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateDate();
    }

    void GenerateDate()
    {
        talkData.Add(1, new string[] {"오른쪽은 마을, 왼쪽은 출입금지 구역, 앞으로 나아가면 ---(글자가 훼손되어있다.)"});

        talkData.Add(100, new string[] {"안녕하세요.", "처음 보시는 분이네요.", "마을에는 무슨 일이신가요?"});

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
