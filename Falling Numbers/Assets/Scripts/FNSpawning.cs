using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FNSpawning : MonoBehaviour
{
    public GameObject fnPrefab;
    public Canvas canvas;
    Vector2 startingPosition;
    float timeToSpawn = 0.8f;
    float timer = 0f;
    float maxDistance;
    void Start()
    {
        SetMaxDistance();
        
    }

    void Update()
    {
        CountDown();
    }


    void SetMaxDistance()
    {
        maxDistance = Screen.width / 2 - fnPrefab.GetComponent<RectTransform>().sizeDelta.x / 2;
    }

    void SpawnFN()
    {
        GameObject fn = Instantiate(fnPrefab, canvas.transform);
        startingPosition = new Vector2(Random.Range(-maxDistance, maxDistance), 60f);
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
