using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text txtCurrentTotal;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void DisplayUIValues(int currentTotal)
    {
        txtCurrentTotal.text = currentTotal.ToString();
    }
}
