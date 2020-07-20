using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLight : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    bool Onecheck = false;
    bool Twocheck = false;
    public GameObject night;
    public GameObject wizard;
    public static int characterNum = 0;

    public void SelectOneCharacter()
    {
        if (Onecheck != true)
        {
            playerOne.SetActive(true);
            night.SetActive(true);
            Onecheck = true;
            if (Twocheck == true)
            {
                playerTwo.SetActive(false);
                wizard.SetActive(false);
                Twocheck = false;
            }
        }
        else
        {
            playerOne.SetActive(false);
            night.SetActive(false);
            Onecheck = false;
        }
    }

    public void SelectTwoCharacter()
    {
        if (Twocheck != true)
        {
            playerTwo.SetActive(true);
            wizard.SetActive(true);
            Twocheck = true;
            if (Onecheck == true)
            {
                playerOne.SetActive(false);
                night.SetActive(false);
                Onecheck = false;
            }
        }
        else
        {
            playerTwo.SetActive(false);
            wizard.SetActive(false);
            Twocheck = false;
        }
    }

    public void NextStage()
    {
        
    }
}
