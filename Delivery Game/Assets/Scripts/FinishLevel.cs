using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public void FinishLvl()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
