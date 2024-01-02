using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator settingsAnim;
    public Animator menuAnim;

    public string buttonName;

    private void Awake()
    {
        CloseSettings();
    }

    public void OpenMenu()
    {
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

    public string GetButtonName()
    {
        return buttonName;
    }
}
