using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    public Text Resolution;
    public Button Start;
    public Button Option;
    public Button Exit;
    public Button Return;
    public Text Volume;
    public Image Fade;

    bool isoption = true;

    public void StartButton()
    {
        Fade.gameObject.SetActive(true);
        Invoke("InVokeMove", 2f);
    }

    void InVokeMove()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void OptionButton()
    {
        if (isoption != true)
        {
            OffOption();
            isoption = true;
        }
        else
        {
            OnOption();
            isoption = false;
        }
    }

    void OnOption()
    {
        Resolution.gameObject.SetActive(true);
        Start.gameObject.SetActive(false);
        Option.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        Return.gameObject.SetActive(true);
        Volume.gameObject.SetActive(true);
    }

    void OffOption()
    {
        Resolution.gameObject.SetActive(false);
        Start.gameObject.SetActive(true);
        Option.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);
        Return.gameObject.SetActive(false);
        Volume.gameObject.SetActive(false);
    }
}
