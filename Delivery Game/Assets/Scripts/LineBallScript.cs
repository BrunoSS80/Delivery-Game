using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBallScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private MoveBall moveBall;
    private Vector3 distBall;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        moveBall = GameObject.Find("Delivery").GetComponent<MoveBall>();
        lineRenderer.positionCount = 2;

    }

    void Update()
    {
        distBall = moveBall.transform.position - moveBall.moveForce.transform.position;
        Debug.Log(distBall);
        lineRenderer.SetPosition(0, moveBall.transform.position);
        lineRenderer.SetPosition(1, distBall);
    }
}
