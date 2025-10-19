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
        if (PlayerConfig.starsLevels.TryGetValue(levelNumber, out int val))
        {
            if (val < pointsController.starsWoned)
            {
                PlayerConfig.starsLevels[levelNumber] = pointsController.starsWoned;
            }
        }
        else
        {
            PlayerConfig.starsLevels.Add(levelNumber, pointsController.starsWoned);
        }
        SceneManager.LoadScene("LevelSelector");
    }
}
