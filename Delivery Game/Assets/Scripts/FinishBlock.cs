using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    private bool triggered = false;
    public GameObject finishUI;
    public Animator animatorBlock;
    public ParticleSystem particleBox, particleBox2, particleBox3;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;
        if (!triggered && collision.CompareTag("Player"))
        {
            particleBox.Play();
            particleBox2.Play();
            particleBox3.Play();
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            animatorBlock.SetTrigger("Finish");
            rb.simulated = false;
            triggered = true;
            finishUI.SetActive(true);
        }
    }
}
