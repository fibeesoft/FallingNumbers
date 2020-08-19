using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FNSpawning : MonoBehaviour
{
    public GameObject fnPrefab;
    public Canvas canvas;
    Vector2 startingPosition;
    float timeToSpawn = 1f;
    float timer = 0f;
    void Start()
    {
        startingPosition = new Vector2(0f, 60f);
    }

    void Update()
    {
        CountDown();
    }

    void SpawnFN()
    {
        GameObject fn = Instantiate(fnPrefab, canvas.transform);
        fn.GetComponent<RectTransform>().anchoredPosition = startingPosition;
    }

    void CountDown()
    {
        timer += Time.deltaTime;
        if(timer > timeToSpawn)
        {
            SpawnFN();
            timer = 0f;
        }
    }
}
