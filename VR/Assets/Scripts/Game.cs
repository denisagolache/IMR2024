using System.Collections;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject golfBall;  
    public Transform holePosition;  
    public TextMeshProUGUI scoreText;  
    private int numberOfHits = 0;  
    private int timesInHole = 0; 
    private int score = 0;
    private bool ballInHole = false;  

    void Start()
    {
       
    }

    void Update()
    {
        if (!ballInHole && Vector3.Distance(golfBall.transform.position, holePosition.position) < 0.5f)
        {
            ballInHole = true;  

            if (numberOfHits == 1)  
            {
                score = 60;  
            }
            else
            {
                score += 20; 
            }

            if (score >= 60) 
            {
                ShowVictoryMessage();  
            }
            else
            {
                UpdateScore();  
            }

            ResetBallPosition(); 
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score + " | Fixed shots: " + numberOfHits;
    }
    void ShowVictoryMessage()
    {
        scoreText.text = "Victory!";
    }

   void HitFairway()
    {
        numberOfHits++;

    }

    void ResetBallPosition()
    {
        golfBall.transform.position = new Vector3(0, 0.5f, 0); 
        ballInHole = false; 
    }
}
