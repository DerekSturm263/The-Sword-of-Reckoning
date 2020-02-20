using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRaycast : MonoBehaviour
{
    public GameObject gameManager;
    public LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.forward);
    }
}