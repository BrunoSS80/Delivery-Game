using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Build.Content;
using UnityEngine;

public class LehtalBlock : MonoBehaviour
{
    private bool triggered = false;

    public FadeDead fadeDead;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;
        if (!triggered && collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.simulated = false;
            triggered = true;
            fadeDead.TriggerDeathFade(collision.transform.position);
        }
    }
}
