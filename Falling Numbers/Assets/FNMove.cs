using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FNMove : MonoBehaviour
{
    float fallingSpeed = 120f;
    Vector2 moveDirection;
    RectTransform rt;
    void Start()
    {
        moveDirection = new Vector2(0f, -1f);
        rt = GetComponent<RectTransform>();
    }


    void Update()
    {
        MoveDown();
    }

    void MoveDown()
    {
        rt.anchoredPosition += moveDirection * Time.deltaTime * fallingSpeed;
    }
}
