using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBallScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private MoveBall moveBall;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        moveBall = GameObject.Find("Delivery").GetComponent<MoveBall>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        lineRenderer.SetPosition(0, moveBall.transform.position);
        lineRenderer.SetPosition(1, moveBall.moveForce.transform.position);
    }
}
