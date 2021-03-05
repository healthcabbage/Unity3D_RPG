using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public Text nameText;
    public GameObject scanObject;
    public bool isAction;
    public bool isPause;
    public int talkIndex;
    public GameObject PausePanel;
    public GameObject OptionPanel;
    public bool isOption = true;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        string nameData = talkManager.GetName(id,talkIndex);
        string talkData = talkManager.GetTalk(id,talkIndex);

        if (talkData == null && nameData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        if (isNpc)
        {
            nameText.text = nameData;
            talkText.text = talkData;
        }
        else
        {
            nameText.text = nameData;
            talkText.text = talkData;
        }

        isAction = true;
        talkIndex++;
    }

    public void PauseGame()
    {
        if (Time.timeScale != 0)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
            isPause = true;
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
            isPause = false;
        }
    }

    public void Option()
    {
        if (isOption)
        {
            OptionPanel.SetActive(true);
            isOption = false;
        }
        else
        {
            OptionPanel.SetActive(false);
            isOption = true;
        }
    }
}
