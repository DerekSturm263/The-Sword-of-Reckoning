using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject selectedTower;
    public Transform selectionPos;

    public bool isPointingAtSurface;

    void Start()
    {
        
    }

    void Update()
    {
        Ray controllerRay = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward, Color.blue);

        if (Physics.Raycast(controllerRay, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Environment"))
            {
                // Set selectionPos to where the Raycast crosses the ground.
            }
        }

        if (isPointingAtSurface && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            // Instantiate selectedTower at selectionPos.
        }
    }
}
