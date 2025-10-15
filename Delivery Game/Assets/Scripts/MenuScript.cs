using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator menuAnimation, restartAnimation ,musicAnimation, backAnimation;
    public bool menuActivated;
    public void MenuOptions()
    {
        restartAnimation.SetTrigger("Slide");
        backAnimation.SetTrigger("Slide");
        musicAnimation.SetTrigger("Slide");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
