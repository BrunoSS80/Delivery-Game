using UnityEngine;
using UnityEngine.UI;

public class TakeStarsLevel : MonoBehaviour
{
    public Sprite withStar;
    public int level, starActive;
    public Image startImg;

    void Start()
    {
        int stars = SaveService.saveService.PlayerConfig.starsLevels[level];

        if (stars >= starActive)
        {
            startImg.sprite = withStar;
        }
    }
}
