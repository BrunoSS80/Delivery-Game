using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FadeDead fadeDead;
    public GameObject ball, claw, grid,moveObjectTag;
    public bool clawMovingBall, gridOn;
    private MoveBall moveBall;
    public Transform moveObjectUI;
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

    public void DesableGrid()
    {
        grid.SetActive(gridOn);
        gridOn = !gridOn;
    }

    public void RotateBlock()
    {
        if (moveObjectTag.CompareTag("Slime"))
        {
            moveObjectUI.Rotate(0, 0, -90);
        }else{
            moveObjectUI.Rotate(0, 0, -45);
        }
    }
    public void MoveObjX(int moveX){
        moveObjectUI.position = moveObjectUI.position + new Vector3(moveX, 0);
    }
    public void MoveObjY(int moveY){
        moveObjectUI.position = moveObjectUI.position + new Vector3(0, moveY);
    }
}
