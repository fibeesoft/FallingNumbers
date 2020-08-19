using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FNSpawning : MonoBehaviour
{
    public GameObject fnPrefab;
    public Canvas canvas;
    Vector2 startingPosition;
    void Start()
    {
        startingPosition = new Vector2(0f, 60f);
        SpawnFN();
    }

    void Update()
    {
        
    }

    void SpawnFN()
    {
        GameObject fn = Instantiate(fnPrefab, canvas.transform);
        fn.GetComponent<RectTransform>().anchoredPosition = startingPosition;
    }
}
