﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public bool IsGameON { get; set; }
    public UIManager uiManager;
    public GameObject menuPanel;
    int targetPoints = 21;
    int currentTotal = 0;
    float gameTimer = 20f;
    int lastClickedButtonValue = 0;


    private void Start()
    {
        IsGameON = true;
        SwitchMenuPanel();
        UpdateUIValues();
    }

    private void Update()
    {
        CountDown();
    }

    void CountDown()
    {
        if (IsGameON)
        {
            gameTimer -= Time.deltaTime;
            print(gameTimer);

            if(gameTimer < 0)
            {
                GameOver();
            }

        }
    }
    public void SwitchMenuPanel()
    {
        if (menuPanel.activeInHierarchy)
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void GetButtonValue(int btnValue)
    {
        print(btnValue);
        lastClickedButtonValue = btnValue;
        CalculateTotal();
        UpdateUIValues();
        CheckNumberOfPoints();
    }

    void CalculateTotal()
    {
        currentTotal += lastClickedButtonValue;
        print(currentTotal);
    }

    void UpdateUIValues()
    {
        uiManager.DisplayUIValues(currentTotal, targetPoints);
    }

    void CheckNumberOfPoints()
    {
        if(currentTotal == targetPoints)
        {
            WinTheGame();
        }
        else if (currentTotal > targetPoints)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        IsGameON = false;
        uiManager.SwitchGameOverPanel();
    }

    void WinTheGame()
    {
        uiManager.SwitchWinPanel();
    }

    public void ReloadTheScene(float delay)
    {
        Time.timeScale = 1f;
        StartCoroutine(ReloadScene());

        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(delay);

            SceneManager.LoadScene(0);
        }
    }
}
