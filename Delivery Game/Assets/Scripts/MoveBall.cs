using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
        activeLineRenderer = true;
        DirectionBall();
    }
    private void Update()
    {
        lastVelocity = rb_Ball.linearVelocity;
    }

    private void DirectionBall()
    {
        force = Vector3.Distance(moveForce.transform.position, transform.position);
        if (force > maxForce.transform.localPosition.magnitude)
        {
            force = 3;
        }
        direction.x = Mathf.Clamp(moveForce.transform.localPosition.x, -4.5f, 4.5f);
        direction.y = Mathf.Clamp(moveForce.transform.localPosition.y, -4.5f, 4.5f);
    }

    public void ShootBall()
    {
        rb_Ball.bodyType = RigidbodyType2D.Dynamic;
        rb_Ball.AddForce(-direction * force, ForceMode2D.Impulse);
        activeLineRenderer = false;
    }
}
