﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;


	// Use this for initialization
	void Start () {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateLives(int changeInLives) {
        lives += changeInLives;

        //no lives left and trigger end of game
        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    void GameOver() {
        gameOver = true;
        gameOverPanel.SetActive(true);

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Shaolin");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
