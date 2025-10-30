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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
            SaveService.saveService.PlayerConfig.currentLevel = newLevel;
            SaveService.saveService.SaveGame();
        }
    }
    public void SetOnLoadLevel(int loadedLevel)
    {
        currentLevel = loadedLevel;
    }
    public void LoadLevel(int loadLevel)
    {
        if (loadLevel <= currentLevel)
        {
            SceneManager.LoadScene(loadLevel);
        }
        else { return; }
    }
    
    public void SetStartLevel(int levelFinished, int starsWon)
    {
        SaveService.saveService.PlayerConfig.starsLevels[levelFinished] = starsWon;
        Debug.Log($"Fez: {starsWon}");
        SaveService.saveService.SaveGame();
    }
}
