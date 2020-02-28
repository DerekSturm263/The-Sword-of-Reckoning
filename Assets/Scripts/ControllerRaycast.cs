using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ControllerRaycast : MonoBehaviour
{
    private GameObject gameManager;

    private EventSystem eventSystem;
    public GameObject selected;

    public LineRenderer lineRenderer;
    public Vector3 lineRenderEndPos;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        eventSystem = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Ray controllerRay = new Ray(transform.position + transform.forward * 0.1f, transform.forward);
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("UIElement");

        lineRenderEndPos = transform.position + transform.forward;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, lineRenderEndPos);

        if (Physics.Raycast(controllerRay, out hit, 100f, mask))
        {
            Debug.Log(hit.collider.gameObject.name);

            selected = hit.collider.gameObject;
            eventSystem.SetSelectedGameObject(gameManager.GetComponent<GameManager>().selectingController.GetComponent<ControllerRaycast>().selected);
        }

        if (OVRInput.GetDown(OVRInput.Button.Any))
        {
            gameManager.GetComponent<GameManager>().selectingController = this.gameObject;
        }
    }
}
