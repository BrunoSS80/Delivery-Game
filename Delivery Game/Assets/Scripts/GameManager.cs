using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FadeDead fadeDead;
    public GameObject ball, claw, grid;
    public bool clawMovingBall, gridOn;
    private MoveBall moveBall;
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
        if (clawMovingBall == false)
        {
            ball.transform.position = ball.transform.position;
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DesableGrid() {
        grid.SetActive(gridOn);
        gridOn = !gridOn;
    }
}
