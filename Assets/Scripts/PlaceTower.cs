using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlaceTower : MonoBehaviour
{
    public GameObject selectedTower;
    public Vector3 selectionPos;

    [SerializeField] private bool isPointingAtSurface;

    public OVRInput.Button placeButton;

    void Update()
    {
        Ray controllerRay = new Ray(transform.position + transform.forward * 0.1f, transform.forward);
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Environment");

        if (Physics.Raycast(controllerRay, out hit, 10f, mask))
        {
            isPointingAtSurface = true;

            selectionPos = hit.point;
        }
        
        if (isPointingAtSurface && OVRInput.GetDown(placeButton))
        {
            Instantiate(selectedTower, selectionPos, new Quaternion(0, 0, 0, 0));
        }
    }
}
