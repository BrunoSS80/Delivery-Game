using UnityEngine;

public class SaveService : MonoBehaviour
{
    private PlayerConfig playerConfig = new PlayerConfig();
    private IDataService dataService = new JSONDataService();
    private bool encryptionEnabled = false;

    public void SaveGame()
    {
        dataService.SaveData("/player-config.json", playerConfig, encryptionEnabled);
    }

    public void LoadGame()
    {
        dataService.LoadData<PlayerConfig>("/player-config.json", encryptionEnabled);
        LevelManager.levelManager.SetCurrentLevel(playerConfig.currentLevel);
    }
    
    public void stars()
    {
        Debug.Log(playerConfig.starsLevels[1]);
    }
}
