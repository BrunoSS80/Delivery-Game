using System.Collections.Generic;
using UnityEngine;

public class SaveService : MonoBehaviour
{
    private PlayerConfig playerConfig = new PlayerConfig();
    private IDataService dataService = new JSONDataService();
    private bool encryptionEnabled = false;
    public static SaveService saveService;
    private void Awake()
    {
        if (saveService == null)
        {
            saveService = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadGame();
    }
    public PlayerConfig PlayerConfig => playerConfig;
    public void SaveGame()
    {
        dataService.SaveData("/player-config.json", playerConfig, encryptionEnabled);
    }

    public void LoadGame()
    {
        playerConfig = dataService.LoadData<PlayerConfig>("/player-config.json", encryptionEnabled);
        LevelManager.levelManager.SetOnLoadLevel(playerConfig.currentLevel);
    }
    
    public void stars()
    {
        Debug.Log(playerConfig.starsLevels[1]);
    }
}
