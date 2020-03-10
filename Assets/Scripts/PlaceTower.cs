using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject gameManager;

    public Vector3 selectionPos;

    [SerializeField] private bool isPointingAtSurface;
    [SerializeField] private bool isPointingAtEmpty;

    public OVRInput.Button placeButton;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        if (GetComponent<OVRGrabber>().grabbedObject != null && GetComponent<OVRGrabber>().grabbedObject.CompareTag("Wand"))
        {
            Ray controllerRay = new Ray(transform.position + transform.forward * 0.1f, transform.forward);
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Environment");

            gameManager.GetComponent<GameManager>().towerHighlight = gameManager.GetComponent<GameManager>().selectedTower.GetComponent<TowerData>().highlightVersion;

            if (Physics.Raycast(controllerRay, out hit, 5f, mask))
            {
                // Creates a highlight of where a tower will be placed where the player is pointing.
                isPointingAtSurface = true;

                selectionPos = hit.point + new Vector3(0, 1, 0);

                /*
                    INSERT CODE THAT WILL BE USED TO DETERMINE WHETHER OR NOT THE SPACE IS EMPTY. IF THE SPACE IS EMPTY, THE TOWER HIGHLIGHT WILL BE BLUE, IF NOT, THE TOWER HIGHLIGHT WILL BE RED.
                */

                gameManager.GetComponent<GameManager>().towerHighlight.transform.position = selectionPos;
            }
            else
            {
                // If they aren't pointing within 5 units of themselves, the tower highlight goes away and they can't place a tower.
                isPointingAtSurface = false;
                isPointingAtEmpty = false;

                gameManager.GetComponent<GameManager>().towerHighlight.transform.position = new Vector3(0, -10, 0);
            }

            if (isPointingAtSurface && isPointingAtEmpty && OVRInput.GetDown(placeButton))
            {
                // Creates a new tower where the player is pointing if they have enough mana.
                if (gameManager.GetComponent<GameManager>().currentMana >= gameManager.GetComponent<GameManager>().selectedTower.GetComponent<TowerData>().manaUse)
                {
                    Instantiate(gameManager.GetComponent<GameManager>().selectedTower, selectionPos, new Quaternion(0, 0, 0, 0));
                    gameManager.GetComponent<GameManager>().currentMana -= gameManager.GetComponent<GameManager>().selectedTower.GetComponent<TowerData>().manaUse;
                }
            }
        }
    }
}
