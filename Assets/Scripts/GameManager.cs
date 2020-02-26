using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup mainUI;
    public CanvasGroup settingsUI;

    // Music related settings.
    public float sfxVolume = 1f;
    public float musicVolume = 1f;

    // Gameplay related settings.
    public bool gestureControls = true;

    // Cheats related settings;
    public bool cantLose = false;
    public bool infiniteMana = false;
    public bool weakEnemies = false;
    public bool swordAtStart = false;
    public int startLevel = 1;

    public bool isSettingsOpen = false;

    void Start()
    {
        mainUI = GameObject.FindGameObjectWithTag("CanvasUI").GetComponent<CanvasGroup>();
        settingsUI = GameObject.FindGameObjectWithTag("SettingsUI").GetComponent<CanvasGroup>();
    }

    public void Play()
    {
        mainUI.GetComponent<AudioSource>().Play();

        StartCoroutine(FadeOutLerp(mainUI));
    }

    public void OpenSettings()
    {
        isSettingsOpen = true;
        StartCoroutine(FadeInLerp(settingsUI));
    }

    public void CloseSettings()
    {
        isSettingsOpen = false;
        StartCoroutine(FadeOutLerp(settingsUI));
    }

    private IEnumerator FadeOutLerp(CanvasGroup ui)
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

    private IEnumerator FadeInLerp(CanvasGroup ui)
    {
        ui.interactable = true;
        ui.blocksRaycasts = true;

        for (int i = 100; i > 0; i--)
        {
            ui.alpha += 0.01f;
            yield return new WaitForEndOfFrame();
        }

        ui.alpha = 1f;
    }
}