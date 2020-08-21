using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FNMain : MonoBehaviour
{
    public int FallingNumberValue { get; set; }
    AudioSource audios;
    SoundManager soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        audios = GetComponent<AudioSource>();
        FallingNumberValue = Random.Range(1, 7);
        GetComponentInChildren<Text>().text = FallingNumberValue.ToString();
        Destroy(gameObject, 8f);
    }


    void Update()
    {
        
    }

    public void DoOnButtonClick()
    {
        GameManager.Instance.GetButtonValue(FallingNumberValue);
        if (soundManager.IsSoundOn)
        {
            audios.Play();
        }
        DestroyNumber();
    }

    void DestroyNumber()
    {
        GetComponent<Animator>().SetTrigger("destroy");
        Destroy(gameObject, 1f);
    }
}
