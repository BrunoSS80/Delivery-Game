using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallReflect : MonoBehaviour
{
    public float forceReflect = 1f;
    public Vector2 reflectDir;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = Vector2.Reflect(rb.position, reflectDir);
            rb.AddForce(direction * forceReflect, ForceMode2D.Impulse);
        }
    }
}
