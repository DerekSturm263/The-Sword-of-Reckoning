using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup ui;

    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("CanvasUI").GetComponent<CanvasGroup>();
    }

    void Update()
    {
        
    }

    public void Play()
    {
        ui.GetComponent<AudioSource>().Play();
        StartCoroutine(FadeLerp());
    }

    private IEnumerator FadeLerp()
    {
        ui.interactable = false;
        ui.blocksRaycasts = false;

        for (int i = 0; i < 100; i++)
        {
            ui.alpha -= 0.01f;
            yield return new WaitForEndOfFrame();
        }

        ui.alpha = 0f;
    }
}
