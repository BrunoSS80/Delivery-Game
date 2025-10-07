using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Rigidbody2D rb_Ball;
    public float force;
    public Transform moveForce, maxForce;
    public Vector3 direction, scanPos, screenPoint;
    public bool activeLineRenderer, launched;
    public Vector2 lastVelocity;
    void Start()
    {
        rb_Ball = GetComponent<Rigidbody2D>();
        activeLineRenderer = true;
        DirectionBall();
    }
    private void Update()
    {
        if (GameManager.Instance.clawMovingBall == false)
        {
            lastVelocity.x = Mathf.Clamp(rb_Ball.linearVelocity.x, -4.5f, 4.5f);
            lastVelocity.y = Mathf.Clamp(rb_Ball.linearVelocity.y, -4.5f, 4.5f);
            rb_Ball.gravityScale = 1;
        }
        if (GameManager.Instance.clawMovingBall == true)
        {
            lastVelocity.x = 0;
            lastVelocity.y = 0;
            rb_Ball.gravityScale = 0;
        }
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
        if (!launched)
        {
            rb_Ball.bodyType = RigidbodyType2D.Dynamic;
            rb_Ball.AddForce(-direction * force, ForceMode2D.Impulse);
            rb_Ball.AddTorque(20);
            activeLineRenderer = false;
            GameManager.Instance.OffLaunchButton();
            launched = !launched;
        }
    }
}
