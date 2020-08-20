using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text txtCurrentTotal;
    public Text txtTargetPoints;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void DisplayUIValues(int currentTotal, int targetTotal)
    {
        txtCurrentTotal.text = currentTotal.ToString();
        txtTargetPoints.text = targetTotal.ToString();
    }
}
