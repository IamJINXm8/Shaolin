﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour {

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit button pushed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Shaolin");
    }

    public GameObject creditPanel;
    public void CreditPanel()
    {
        creditPanel.SetActive(true);
    }
    


}
