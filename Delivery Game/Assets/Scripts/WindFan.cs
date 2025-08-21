using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindFan : MonoBehaviour
{
    public float windForce = 1f;
    public Vector2 windDirection = Vector2.up;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.AddForce(windDirection.normalized * windForce, ForceMode2D.Impulse);
        }
    }
}
