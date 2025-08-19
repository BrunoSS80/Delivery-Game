using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Rigidbody2D rb_Ball;
    public float force;
    public Transform moveForce, maxForce;
    public Vector3 direction, scanPos, screenPoint;
    public bool activeLineRenderer;
    public Vector2 lastVelocity;
    void Start()
    {
        rb_Ball = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        lastVelocity = rb_Ball.velocity;
    }

    private void OnMouseDown()
    {
        activeLineRenderer = true;
        scanPos = moveForce.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDrag()
    {
        screenPoint = scanPos + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveForce.transform.position = screenPoint;
        force = Vector3.Distance(moveForce.transform.position, transform.position);
        if (force > maxForce.transform.localPosition.magnitude)
        {
            force = 3;
        }
        direction.x = Mathf.Clamp(moveForce.transform.localPosition.x, -4.5f, 4.5f);
        direction.y = Mathf.Clamp(moveForce.transform.localPosition.y, -4.5f, 4.5f);
    }

    private void OnMouseUp()
    {
        rb_Ball.bodyType = RigidbodyType2D.Dynamic;
        rb_Ball.AddForce(-direction * force, ForceMode2D.Impulse);
        moveForce.transform.position = transform.position;
        activeLineRenderer = false;
    }
}
