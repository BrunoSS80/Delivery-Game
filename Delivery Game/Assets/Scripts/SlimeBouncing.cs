using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBouncing : MonoBehaviour
{
    public float speedMultiplier = 1f; 
    public float minSpeed = 3f;
    private Transform selected;
    private GameObject selectedTag;
    public Animator animatorSlime;

    private void Start()
    {
        selected = this.transform;
        selectedTag = this.gameObject;
    }    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;
        if (rb == null) return;
        Vector2 velocity = rb.GetComponent<MoveBall>().lastVelocity;
        animatorSlime.SetTrigger("Hit");

        if (collision.contactCount > 0)
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflected = Vector2.Reflect(velocity, normal).normalized;
            reflected = new Vector2(reflected.x, reflected.y + 0.5f);

            float speed = velocity.magnitude;
            speed = Mathf.Max(speed * speedMultiplier, minSpeed);

            rb.linearVelocity = reflected * speed;
        }
    }

    void OnMouseUp()
    {
        GameManager.Instance.moveObjectUI = selected;
        GameManager.Instance.moveObjectTag = selectedTag;
    }
}