using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    public int score = 0; 

    public void AddScore()
    {
        score++;
        text.text = score.ToString() + " Goods Collected";
    }
}
