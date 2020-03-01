using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DebugTower : MonoBehaviour
{
    public GameObject leftController;
    public GameObject rightController;

    void Update()
    {
        transform.position = leftController.GetComponent<PlaceTower>().selectionPos;
    }
}
