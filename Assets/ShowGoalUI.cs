using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGoalUI : MonoBehaviour
{
    public GameManager gameManager;

    public void ShowUIObjects()
    {
        gameManager.ShowGoal();
    }
}
