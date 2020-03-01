using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private CanvasGroup mainUI;
    private CanvasGroup settingsUI;

    [HideInInspector] public bool isSettingsOpen = false;

    [Header("Settings")]

    [Range(0f, 1f)] public float sfxVolume = 1f;
    [Range(0f, 1f)] public float musicVolume = 1f;

    public bool gestureControls = true;

    public bool cantLose = false;
    public bool infiniteMana = false;
    public bool weakEnemies = false;
    public bool swordAtStart = false;
    public int startLevel = 1;

    [Header("Game Data")]

    public GameObject activeController;
    public uint currentLevel = 0;
    public uint score = 0;
    public float maxMana = 100;
    public float currentMana = 100;

    void Start()
    {
        mainUI = GameObject.FindGameObjectWithTag("CanvasUI").GetComponent<CanvasGroup>();
        settingsUI = GameObject.FindGameObjectWithTag("SettingsUI").GetComponent<CanvasGroup>();
        activeController = GameObject.FindGameObjectWithTag("RightController");
    }

    #region Button Methods

    // Method for the button. Runs the Play() method from the GameManager script.
    public void StartGame()
    {
        Play();
    }

    // Method for the button. Makes the settings panel visible.
    public void LaunchSettings()
    {
        GetComponent<GameManager>().OpenSettings();
    }

    // Method for the button. Takes the user to the credits scene.
    public void LaunchCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    // Method for the button. Quits the application.
    public void Quit()
    {
        Application.Quit();
    }

    #endregion

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