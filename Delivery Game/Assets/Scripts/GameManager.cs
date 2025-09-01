using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FadeDead fadeDead;
    public GameObject ball, claw;
    public bool clawMovingBall;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        fadeDead = GetComponent<FadeDead>();
    }

    void Update()
    {
        if (clawMovingBall == true)
        {
            ball.transform.position = claw.transform.position;
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
