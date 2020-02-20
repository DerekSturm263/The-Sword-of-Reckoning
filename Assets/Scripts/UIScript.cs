using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject leftHand, rightHand;

    // Method for the button. Runs the Play() method from the GameManager script.
    public void StartGame()
    {
        //GetComponent<GameManager>().Play();
    }

    // Method for the button. Makes the settings panel visible.
    public void LaunchSettings()
    {

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

    void Start()
    {
        eventSystem = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();
    }

    void Update()
    {
        RaycastHit hit;

        //eventSystem.SetSelectedGameObject();
    }
}