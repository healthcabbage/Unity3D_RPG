using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLight : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    bool Onecheck = false;
    bool Twocheck = false;
    public GameObject night;
    public GameObject wizard;
    public static int characterNum = 0;
    public Image Fadeout;
    public Animator anim;
    public Animator Wizardanim;
    public Text Noselect;
    bool SelectCharactercheck = false;

    void Start()
    {
        Invoke("HideFadeOut", 1f);
    }

    public void SelectOneCharacter()
    {
        if (Onecheck != true)
        {
            playerOne.SetActive(true);
            night.SetActive(true);
            Onecheck = true;
            characterNum = 0;
            anim.SetBool("Select_Motion", true);
            SelectCharactercheck = true;
            if (Twocheck == true)
            {
                playerTwo.SetActive(false);
                wizard.SetActive(false);
                Twocheck = false;
                Wizardanim.SetBool("Wizard_select", false);
            }
        }
        else
        {
            playerOne.SetActive(false);
            night.SetActive(false);
            Onecheck = false;
            anim.SetBool("Select_Motion", false);
            SelectCharactercheck = false;
        }
    }

    public void SelectTwoCharacter()
    {
        if (Twocheck != true)
        {
            playerTwo.SetActive(true);
            wizard.SetActive(true);
            Twocheck = true;
            Wizardanim.SetBool("Wizard_select", true);
            characterNum = 1;
            SelectCharactercheck = true;
            if (Onecheck == true)
            {
                playerOne.SetActive(false);
                night.SetActive(false);
                Onecheck = false;
                anim.SetBool("Select_Motion", false);
            }
        }
        else
        {
            playerTwo.SetActive(false);
            wizard.SetActive(false);
            Twocheck = false;
            Wizardanim.SetBool("Wizard_select", false);
            SelectCharactercheck = false;
        }
    }

    void HideFadeOut()
    {
        Fadeout.gameObject.SetActive(false);
    }

    void NextMove()
    {
        SceneManager.LoadScene("Stage01");
    }

    public void NextStage()
    {
        if (SelectCharactercheck != false)
        {
            Fadeout.gameObject.SetActive(true);
            FadeIn fadein = GameObject.Find("FadeOut").GetComponent<FadeIn>();
            fadein.fadeselect = false;
            fadein.Awake();

            Invoke("Loading", 1f);
        }
        else
        {
            Noselect.gameObject.SetActive(true);
            Invoke("HideText", 1f);
        }
    }

    void HideText()
    {
        Noselect.gameObject.SetActive(false);
    }
    void Loading()
    {
        LoadingSceneController.Instance.LoadScene("Stage01");
    }
}
