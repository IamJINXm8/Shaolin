using System.Collections;
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
    public bool win;
    public GameObject gameOverPanel;
    public GameObject loadingPanel;
    public GameObject winPanel;
    public int numberOfBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;


    // Use this for initialization
    void Start() {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;

    }

    // Update is called once per frame
    void Update() {

    }
    public void UpdateLives(int changeInLives) {
        lives += changeInLives;

        //no lives left and trigger end of game
        if (lives <= 0)
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

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
          if(currentLevelIndex >= levels.Length - 1)
            {
                Win();
            } else
            {
                gameOver = true;
                loadingPanel.SetActive(true);
                Invoke("LoadLevel",3f);
                

            }
          
        }
    }

    void LoadLevel()
    {
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameOver = false;
        loadingPanel.SetActive(false);

    }

    
    void Win()
    {
        win = true;
        winPanel.SetActive(true);

    }
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);

    }
   
    public void PlayAgain()
    {
        SceneManager.LoadScene("Shaolin");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
}
