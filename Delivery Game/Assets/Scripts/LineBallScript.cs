using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBallScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private MoveBall moveBall;
    public Transform inicialDirection;
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
        inicialDirection = moveBall.transform;
        launchDirection = -moveBall.moveForce.position;
        launchForce = Mathf.Clamp(moveBall.moveForce.position.magnitude, 0, maxForce);
        DrawnLine();
    }

    void DrawnLine()
    {
        Vector2 startPosition = inicialDirection.position;
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
