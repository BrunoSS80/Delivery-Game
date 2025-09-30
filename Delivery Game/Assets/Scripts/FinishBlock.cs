using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    private bool triggered = false;
    public GameObject finishUI;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;
        if (!triggered && collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.simulated = false;
            triggered = true;
            finishUI.SetActive(true);
        }
    }
}
