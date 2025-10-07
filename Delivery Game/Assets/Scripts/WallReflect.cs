using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallReflect : MonoBehaviour
{
    public float forceReflect = 1f;
    public Vector2 reflectDir;
    public float speedMultiplier = 1f; 
    public float minSpeed = 3f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;
        if (rb == null) return;
        Vector2 velocity = rb.GetComponent<MoveBall>().lastVelocity;

        if (collision.contactCount > 0)
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflected = Vector2.Reflect(velocity, normal).normalized;
            //reflected = new Vector2(reflected.x, reflected.y + 1);

            float speed = velocity.magnitude;
            speed = Mathf.Max(speed * speedMultiplier, minSpeed);

            rb.linearVelocity = reflected * speed;
        }
    }
}
