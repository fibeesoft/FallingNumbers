using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FNMain : MonoBehaviour
{
    public int FallingNumberValue { get; set; }
    void Start()
    {
        FallingNumberValue = Random.Range(1, 7);
        GetComponentInChildren<Text>().text = FallingNumberValue.ToString();
    }


    void Update()
    {
        
    }
}
