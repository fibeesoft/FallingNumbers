using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Font ourFont;
    public Text txtCurrentTotal;
    public Text txtTargetPoints;
    public Text txtGameTimer;
    public Text txtEvenOdd;
    public GameObject menuPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    public Button btnPlay;
    public Button btnKeepPlaying;

    bool isPauseMenuOn;


    void Start()
    {
        ChangeTextFont();
        isPauseMenuOn = false;
        SwitchMenuPanel();
    }


    void Update()
    {
        
    }
    void ChangeTextFont()
    {
        SwitchGameOverPanel();
        SwitchMenuPanel();
        SwitchWinPanel();

        Text[] txtComponents = FindObjectsOfType<Text>();
        foreach (var i in txtComponents)
        {
            i.font = ourFont;
        }

        SwitchGameOverPanel();
        SwitchMenuPanel();
        SwitchWinPanel();
    }

    public void DisplayUIValues(int currentTotal, int targetTotal, bool isEven)
    {
        txtCurrentTotal.text = currentTotal.ToString();
        txtTargetPoints.text = targetTotal.ToString();
        txtEvenOdd.text = isEven ? "EVEN" : "ODD";
    }

    public void DisplayTimerInUI(float time)
    {
        txtGameTimer.text = time.ToString("f2");
    }

    public void SwitchGameOverPanel()
    {
        if (gameOverPanel.activeInHierarchy)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void SwitchWinPanel()
    {
        if (winPanel.activeInHierarchy)
        {
            winPanel.SetActive(false);
        }
        else
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void TurnPauseMenuOn()
    {
        isPauseMenuOn = true;
    }
    public void SwitchMenuPanel()
    {
        if (menuPanel.activeInHierarchy)
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1f;
            isPauseMenuOn = false;
        }
        else
        {
            if (isPauseMenuOn)
            {
                btnKeepPlaying.gameObject.SetActive(true);
                btnPlay.gameObject.SetActive(false);
            }
            else
            {
                btnKeepPlaying.gameObject.SetActive(false);
                btnPlay.gameObject.SetActive(true);
            }
            menuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
