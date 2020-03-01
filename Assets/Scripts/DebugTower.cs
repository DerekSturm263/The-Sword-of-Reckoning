using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTower : MonoBehaviour
{
    private GameObject gameManager;

    void Update()
    {
        transform.position = gameManager.GetComponent<GameManager>().activeController.GetComponent<PlaceTower>().selectionPos;
    }
}
