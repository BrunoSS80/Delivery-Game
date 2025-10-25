using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    private static int currentLevel = 1;
    private PlayerConfig playerConfig = new PlayerConfig();

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
            playerConfig.currentLevel = newLevel;
            Debug.Log(playerConfig.currentLevel);
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
