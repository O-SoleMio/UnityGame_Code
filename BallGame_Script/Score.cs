using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    
    public GameObject scoreBoardObj;
    Text scoreBoard;

    string new_Line = System.Environment.NewLine;
    int scoreResult = 0;
    int score = 0;
    
    CharControl charControl;
    GameManager gameManager;
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        charControl = GameObject.Find("Player").GetComponent<CharControl>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreBoardObj = GameObject.Find("ScoreCanvas").transform.Find("scoreBoard").gameObject;
        scoreBoard = scoreBoardObj.transform.Find("ScoreText").gameObject.GetComponent<Text>();
        StartCoroutine(CheckScore());        
    }
  
    IEnumerator CheckScore()
    {
        score = 1 * gameManager.scoreMag;
        while(true)
        {                 
            scoreResult += score;
            scoreText.text = scoreResult.ToString();
            if(charControl.gameOver == true)
            {             
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }        
        scoreBoard.text =
            new_Line + "Your Score" + new_Line + scoreResult.ToString();
        scoreBoardObj.SetActive(true);
        Time.timeScale = 0;

    }    
}
