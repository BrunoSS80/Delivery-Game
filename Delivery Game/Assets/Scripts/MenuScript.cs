using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator menuAnimation, musicAnimation, backAnimation;
    public bool menuActivated;
    public void MenuOptions()
    {
        
            backAnimation.SetTrigger("Slide");
            musicAnimation.SetTrigger("Slide");
        
        
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
