using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void LevelSelector()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
