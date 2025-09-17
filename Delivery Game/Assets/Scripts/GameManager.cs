using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FadeDead fadeDead;
    public GameObject ball, claw, grid, moveObjectTag, createBar, moveBar, editBar, edtiButton, launchButton;
    public bool clawMovingBall, gridOn;
    private MoveBall moveBall;
    public Transform moveObjectUI;
    public Camera mainCamera, secundCamera;
    public bool editMode;
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

        if (moveObjectUI != null && editMode == true)
        {
            createBar.SetActive(false);
            moveBar.SetActive(true);
        }
        else if (moveObjectUI == null && editMode == true)
        {
            createBar.SetActive(true);
            moveBar.SetActive(false);
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void DesableGrid()
    {
        gridOn = !gridOn;
        grid.SetActive(gridOn);
    }
    private void FadeCameraCall()
    {
        if (!editMode)
        {
            mainCamera.depth = 0f;
            secundCamera.depth = 1f;
            editBar.SetActive(true);
            edtiButton.transform.position = new Vector2(edtiButton.transform.position.x, edtiButton.transform.position.y + 65f);
            launchButton.SetActive(false);
        }
        else if (editMode)
        {
            mainCamera.depth = 1f;
            secundCamera.depth = 0f;
            editBar.SetActive(false);
            edtiButton.transform.position = new Vector2(edtiButton.transform.position.x, edtiButton.transform.position.y - 65f);
            launchButton.SetActive(true);
        }
        editMode = !editMode;
    }
    public void EditButtonClicked()
    {
        DesableGrid();
        FadeCameraCall();
    }
    public void RotateBlock()
    {
        if (moveObjectTag.CompareTag("Slime"))
        {
            moveObjectUI.Rotate(0, 0, -90);
        }
        else
        {
            moveObjectUI.transform.Rotate(0, 0, -45f, Space.Self);
        }
    }
    public void MoveObjX(int moveX)
    {

        moveObjectUI.position = moveObjectUI.position + new Vector3(moveX, 0);
    }
    public void MoveObjY(int moveY)
    {
        moveObjectUI.position = moveObjectUI.position + new Vector3(0, moveY);
    }
    public void ConfirmButton()
    {
        moveObjectTag = null;
        moveObjectUI = null;
    }
}
