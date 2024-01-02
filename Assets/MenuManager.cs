using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public MainMenu mainMenu;

    public void TestingMethod()
    {
        if(mainMenu.GetButtonName().Equals("settings"))
        {
            mainMenu.OpenSettings();
        }
    }
}
