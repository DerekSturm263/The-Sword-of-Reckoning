using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTower : MonoBehaviour
{
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        transform.position = gameManager.GetComponent<GameManager>().activeController.GetComponent<PlaceTower>().selectionPos;
    }
}
