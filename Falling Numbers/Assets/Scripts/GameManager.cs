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
    public UIManager uiManager;
    public GameObject menuPanel;
    int targetPoints = 21;
    int currentTotal = 0;
    int lastClickedButtonValue = 0;


    private void Start()
    {
        SwitchMenuPanel();
        UpdateUIValues();
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

    void GameOver()
    {
        ReloadTheScene(1f);
    }

    void WinTheGame()
    {

    }

    void ReloadTheScene(float delay)
    {

        StartCoroutine(ReloadScene());

        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(delay);

            SceneManager.LoadScene(0);
        }
    }
}
