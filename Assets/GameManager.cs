using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator questAnim;
    public MainMenu mainMenu;
    public CinemachineFreeLook vCam;

    private void Awake()
    {
        OpenQuest();
        mainMenu.PauseGame(vCam);
    }

    public void OpenQuest()
    {
        questAnim.SetBool("QuestIsClosed", false);
    }

    public void CloseQuest()
    {
        questAnim.SetBool("QuestIsClosed", true);
    }
}
