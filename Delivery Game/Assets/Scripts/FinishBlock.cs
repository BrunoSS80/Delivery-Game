using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBlock : MonoBehaviour
{
    private bool triggered = false;
    public GameObject finishUI;
    public Animator animatorBlock;
    public ParticleSystem particleBox, particleBox2, particleBox3;
    public int nextLevel;
    public int levelNumber;
    public PointsController pointsController;
    private PlayerConfig playerConfig = new PlayerConfig();
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
            Finished();
        }
    }

    public void Finished()
    {
        LevelManager.levelManager.SetCurrentLevel(nextLevel);
        if (playerConfig.starsLevels.TryGetValue(levelNumber, out int val))
        {
            if (val < pointsController.starsWoned)
            {
                playerConfig.starsLevels[levelNumber] = pointsController.starsWoned;
            }
        }
        else
        {
            playerConfig.starsLevels[levelNumber] = pointsController.starsWoned;
        }
    }
}
