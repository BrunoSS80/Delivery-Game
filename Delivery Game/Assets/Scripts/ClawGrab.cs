using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ClawGrab : MonoBehaviour
{
    public GameObject pointA, pointB, target;
    public float duration;
    public float elapsedTime,t;
    public bool upClaw;
    private Vector2 startPosition;

    void Start()
    {
        target = pointA;
        startPosition = transform.position;
    }
    void FixedUpdate()
    {
        if (upClaw)
        {
            elapsedTime += Time.deltaTime;
            t = elapsedTime / duration;
            transform.position = Vector2.Lerp(startPosition, target.transform.position, t);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            upClaw = true;
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
