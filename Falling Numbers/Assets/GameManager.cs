using UnityEngine;

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


    int currentTotal = 0;
    int lastClickedButtonValue = 0;


    public void GetButtonValue(int btnValue)
    {
        print(btnValue);
        lastClickedButtonValue = btnValue;
        CalculateTotal();
    }

    void CalculateTotal()
    {
        currentTotal += lastClickedButtonValue;
        print(currentTotal);
    }
}
