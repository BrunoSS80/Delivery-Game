using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBallScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private MoveBall moveBall;
    public Vector2 inicialDirection;
    public Vector2 launchDirection;
    public float launchForce, timeBetweenPoints, maxForce;
    public int lineSegmentCount = 30;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        moveBall = GameObject.Find("Delivery").GetComponent<MoveBall>();
        lineRenderer.positionCount = lineSegmentCount;
        timeBetweenPoints = 0.1f;
    }

    void Update()
    {
        if (moveBall.activeLineRenderer)
        {
            lineRenderer.enabled = true;
            inicialDirection = transform.position;
            launchDirection = -moveBall.moveForce.transform.localPosition;
            launchForce = Mathf.Clamp(moveBall.moveForce.transform.localPosition.magnitude, 0, maxForce);
            DrawnLine();
        }

        if (!moveBall.activeLineRenderer)
        {
            lineRenderer.enabled = false;
        }
    }

    void DrawnLine()
    {
        Vector2 startPosition = inicialDirection;
        Vector2 startVelocity = launchDirection.normalized * launchForce;
        Vector3[] points = new Vector3[lineSegmentCount];

        for (int i = 0; i < lineSegmentCount; i++)
        {
            float t = i * timeBetweenPoints;
            Vector2 position = startPosition + startVelocity * t + 0.1f * Physics2D.gravity * t *t;
            points[i] = position;
        }

        lineRenderer.SetPositions(points);
    }
}
