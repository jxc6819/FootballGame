using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScore : MonoBehaviour
{
    public TotalTargetScore tts;
    public Text scoreText;
    public int score;
   

    public void Update()
    {
        if (tts.isHitt == true)
        {
            Debug.Log("Score Received");
            AddScore();

        }

        void AddScore()
        {
            score = tts.HitCount;
            
           
            scoreText.text = score.ToString();

            

        }

    }
}
