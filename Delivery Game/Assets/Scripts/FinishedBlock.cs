using UnityEngine;

public class FinishedBlock : MonoBehaviour
{
    public GameObject finisheScreen;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.simulated = false;
        finisheScreen.SetActive(true);
    }
}
