using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Method for the button. Runs the Play() method from the GameManager script.
    public void StartGame()
    {
        gameManager.GetComponent<GameManager>().Play();
    }

    // Method for the button. Makes the settings panel visible.
    public void LaunchSettings()
    {
        gameManager.GetComponent<GameManager>().OpenSettings();
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
}