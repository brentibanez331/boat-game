using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator questAnim;
    public MainMenu mainMenu;
    public CinemachineFreeLook vCam;
    bool playTimer = false;
    public TextMeshProUGUI timerText;
    public float remainingTime;

    public int maxGoods;
    int goodsCollected;


    //audio
    public AudioSource timerSFX;  


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
        playTimer = true;
    }
    void PlayTimerSFX()
    {
        timerSFX.PlayOneShot(timerSFX.clip, .8f);
    }

    private void Update()
    {
        
        if (playTimer)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (remainingTime <= 0 && remainingTime > -0.1)
            {   
                
                PlayTimerSFX();
            }

            if(goodsCollected == maxGoods)
            {
                //Player won Game
            }

            if(remainingTime <= 0 && goodsCollected < maxGoods)
            {
                remainingTime = 0;
                minutes = 0;
                seconds = 0;    
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                //Show GameOver Screen
                print("GameOver");
            }
        }

        
    }
}
