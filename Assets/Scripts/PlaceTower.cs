using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject gameManager;

    public Vector3 selectionPos;

    [SerializeField] private bool isPointingAtSurface;

    public OVRInput.Button placeButton;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        if (GetComponent<OVRGrabber>().grabbedObject.name == "Wand")
        {
            Ray controllerRay = new Ray(transform.position + transform.forward * 0.1f, transform.forward);
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Environment");

            gameManager.GetComponent<GameManager>().towerHighlight = gameManager.GetComponent<GameManager>().selectedTower.GetComponent<TowerData>().highlightVersion;

            if (Physics.Raycast(controllerRay, out hit, 5f, mask))
            {
                isPointingAtSurface = true;

                selectionPos = hit.point + new Vector3(0, 1, 0);
                gameManager.GetComponent<GameManager>().towerHighlight.transform.position = selectionPos;
            }
            else
            {
                isPointingAtSurface = false;

                gameManager.GetComponent<GameManager>().towerHighlight.transform.position = new Vector3(0, -10, 0);
            }

            if (isPointingAtSurface && OVRInput.GetDown(placeButton))
            {
                Instantiate(gameManager.GetComponent<GameManager>().selectedTower, selectionPos, new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
