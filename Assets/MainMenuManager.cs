using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator settingsAnim;
    public Animator menuAnim;

    public string buttonName;

    private void Awake()
    {
        CloseSettings();

        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
        {
            CloseMenu();
        }
    }

    public void OpenMenu()
    {
        print("menu opening");
        menuAnim.SetBool("MenuIsClosed", false);
    }

    public void CloseMenu()
    {
        menuAnim.SetBool("MenuIsClosed", true);
        Debug.Log("This is played");
    }

    public void OpenSettings()
    {
        settingsAnim.SetBool("SettingsIsClosed", false);
    }

    public void CloseSettings()
    {
        settingsAnim.SetBool("SettingsIsClosed", true);
        Debug.Log("This is played");
    }

    public void SetButtonName(string buttonName_)
    {
        buttonName = buttonName_;
        print(buttonName);
    }

    public void HidePauseButton(GameObject pauseButton)
    {
        pauseButton.SetActive(false);
    }

    public string GetButtonName()
    {
        return buttonName;
    }
}
