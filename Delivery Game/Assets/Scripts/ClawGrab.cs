using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawGrab : MonoBehaviour
{
    public GameObject pointA, pointB, target, lastPoint;
    public float duration;
    public float elapsedTime,t;
    public bool upClaw;
    private Vector2 startPosition;

    void Start()
    {
        target = pointA;
        startPosition = transform.position;
    }
    void Update()
    {
        if (upClaw)
        {
            float duration = Vector2.Distance(startPosition, target.transform.position);
            elapsedTime += Time.deltaTime;
            t = elapsedTime / (duration/4);
            transform.position = Vector2.Lerp(startPosition, target.transform.position, t);
        }
        if (transform.position == lastPoint.transform.position)
        {
            GameManager.Instance.clawMovingBall = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            upClaw = true;
            GameManager.Instance.clawMovingBall = true;
        }
        if (collision.CompareTag("PointA"))
        {
            StartCoroutine(changeTarget());
        }
    }

    IEnumerator changeTarget()
    {
        yield return new WaitForSeconds(3);
        elapsedTime = 0;
        target = pointB;
        startPosition = pointA.transform.position;
    }
}
