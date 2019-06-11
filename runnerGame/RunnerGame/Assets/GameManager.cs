using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text HighScore, Score;
    int hScore, score;

    public bool isGameStarted;
    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        hScore = PlayerPrefs.GetInt("highScore");
        HighScore.text = hScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isGameStarted = true;
            FindObjectOfType<WallMaker>().createNewWalls();
        }

    }

    internal void Restart()
    {
        SceneManager.LoadScene(0);
    }

    internal void makeScore()
    {
        score++;
        Score.text = score.ToString();

        if (score > hScore)
        {
            hScore = score;
        }
        PlayerPrefs.SetInt("highScore", hScore);

       
    }
}
