using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerRaycast : MonoBehaviour
{
    private GameObject gameManager;
    private EventSystem eventSystem;

    [SerializeField] private GameObject selected;

    private LineRenderer lineRenderer;
    private Vector3 lineRenderEndPos;

    public bool isActive;

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

        if (isActive)
        {
            if (Physics.Raycast(controllerRay, out hit, 100f, mask))
            {
                selected = hit.collider.gameObject;
                eventSystem.SetSelectedGameObject(gameManager.GetComponent<GameManager>().activeController.GetComponent<ControllerRaycast>().selected);
            }
        }
        else
        {
            lineRenderer.SetPosition(0, new Vector3(0, -10f, 0));
            lineRenderer.SetPosition(1, new Vector3(0, -10f, 0));
        }
    }
}
