using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public void FinishLvl()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void PlayLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
