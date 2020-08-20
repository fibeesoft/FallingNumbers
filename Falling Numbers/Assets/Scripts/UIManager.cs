using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text txtCurrentTotal;
    public Text txtTargetPoints;
    public Text txtGameTimer;
    public Text txtEvenOdd;

    public GameObject gameOverPanel;
    public GameObject winPanel;
    void Start()
    {
        
    }


    void Update()
    {
        
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
}
