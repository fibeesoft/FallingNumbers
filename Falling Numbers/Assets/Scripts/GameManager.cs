using System.Collections;
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

    int targetPoints = 21;
    int currentTotal = 0;
    float gameTimer = 20f;
    int lastClickedButtonValue = 0;
    bool isBtnToBeEven;
    bool isBtnEven;



    private void Start()
    {
      
        IsGameON = true;

        SetIfNumberShouldBeEven();
        UpdateUIValues();

    }

    private void Update()
    {
        CountDown();
    }


    void SetIfNumberShouldBeEven()
    {
        if(currentTotal == targetPoints - 1)
        {
            isBtnToBeEven = false;
        }
        else
        {
            int rand = Random.Range(0, 2);
            if(rand == 0)
            {
                isBtnToBeEven = true;
            }
            else
            {
                isBtnToBeEven = false;
            }
        }
    }


    void CountDown()
    {
        if (IsGameON)
        {
            gameTimer -= Time.deltaTime;
            uiManager.DisplayTimerInUI(gameTimer);

            if(gameTimer < 0)
            {
                GameOver();
            }

        }
    }


    public void GetButtonValue(int btnValue)
    {
        lastClickedButtonValue = btnValue;
        isBtnEven = btnValue % 2 == 0 ? true : false;
        CheckIfOddEvenIsValid();
        CalculateTotal();
        SetIfNumberShouldBeEven();
        UpdateUIValues();
        CheckNumberOfPoints();
    }

    void CheckIfOddEvenIsValid()
    {
        if(isBtnEven != isBtnToBeEven)
        {
            GameOver();
        }
    }
    void CalculateTotal()
    {
        currentTotal += lastClickedButtonValue;
        print(currentTotal);
    }

    void UpdateUIValues()
    {
        uiManager.DisplayUIValues(currentTotal, targetPoints, isBtnToBeEven);
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

    public void StartTheGame()
    {
        uiManager.SwitchMenuPanel();
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
