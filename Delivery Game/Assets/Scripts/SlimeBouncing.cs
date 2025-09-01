using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBouncing : MonoBehaviour
{
    public bool rotation = true;
    public Canvas canvasButtons;
    public float speedMultiplier = 1f; // 1 = mantém, >1 acelera
    public float minSpeed = 3f;        // velocidade mínima pós-reflexo
    private void Update()
    {
        canvasButtons.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 0.366f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;
        if (rb == null) return; // só funciona se o objeto tiver Rigidbody2D
        Vector2 velocity = rb.GetComponent<MoveBall>().lastVelocity;

        if (collision.contactCount > 0)
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflected = Vector2.Reflect(velocity, normal).normalized;
            reflected = new Vector2(reflected.x, reflected.y + 1);

            float speed = velocity.magnitude;
            speed = Mathf.Max(speed * speedMultiplier, minSpeed);

            rb.linearVelocity = reflected * speed;
        }
    }

    public void RotationSlime(){
        rotation = !rotation;
        transform.Rotate(0,0,-90);
    }
    public void MoveObjX(int moveX){
        transform.position = transform.position + new Vector3(moveX, 0);
    }
    public void MoveObjY(int moveY){
        transform.position = transform.position + new Vector3(0, moveY);
    }
}