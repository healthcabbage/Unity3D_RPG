using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu_Button : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void ExitButton()
    {
        
    }
}
