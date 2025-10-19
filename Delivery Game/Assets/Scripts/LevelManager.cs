using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    private static int currentLevel = 1;

    public void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetCurrentLevel(int newLevel)
    {
        if (newLevel > currentLevel)
        {
            currentLevel = newLevel;
        }
    }
    
    public void LoadLevel(int loadLevel)
    {
        if (loadLevel <= currentLevel)
        {
            SceneManager.LoadScene(loadLevel);
        }
        else{ return; }
    }
}
