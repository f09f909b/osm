using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Game Manager is NULL");
            }

            return _instance;
        }
    }
    private int _levelNumber;
    private int _levelToBeatGame;
    
    private void Awake()
    {
        _instance = this;
    }

    public void NextLevel()
    {
        _levelNumber++;
        if (_levelNumber == _levelToBeatGame)
        {
            Debug.Log("You beat the game!");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
