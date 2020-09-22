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
        talkData.Add(1, new string[] {"북쪽으로 가면 마을이, 서쪽으로 가면 버섯숲이 나온다.", "현재 동쪽은 출입금지이다. 동쪽에는 ----가 있으니 --해야된다"});

        talkData.Add(100, new string[] {"안녕하세요.", "처음 보시는 분이네요.", "마을에는 무슨 일이신가요?"});
        talkData.Add(200, new string[] {"아무런 소리가 들리지 않는다", "...자세히 들어보니 작은 인기척이 느껴지는 것 같다."});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
