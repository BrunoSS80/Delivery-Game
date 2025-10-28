using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    public float valFan, valSlime;
    public Image imgBar, star1, star2, star3;
    [Header("Value for get Stars")]
    public float valStar3, valStar2, valStar1;
    public Animator star1Anim, star2Anim, star3Anim;
    public int starsWoned;

    void Update()
    {
        CalcStars();
    }

    public void AddFan()
    {
        float percentFan = valFan / 100;
        imgBar.fillAmount -= percentFan;
    }
    public void AddSlime()
    {
        float percentSlime = valSlime / 100;
        imgBar.fillAmount -= percentSlime;
    }
    public void RemoveObj()
    {
        if (GameManager.Instance.moveObjectTag.CompareTag("Slime"))
        {
            imgBar.fillAmount += (valSlime/100);
        }
        else
        {
            imgBar.fillAmount += (valFan/100);
        }
        GameManager.Instance.moveObjectTag.SetActive(false);
        GameManager.Instance.moveObjectTag = null;
        GameManager.Instance.moveObjectUI = null;
    }

    void CalcStars(){
        if (imgBar.fillAmount < valStar3)
        {
            star3.color = new Color32(255, 255, 255, 100);
            starsWoned = 2;
            star3Anim.SetTrigger("LowPoints");
        }
        if (imgBar.fillAmount < valStar2)
        {
            star2.color = new Color32(255, 255, 255, 100);
            starsWoned = 1;
            star2Anim.SetTrigger("LowPoints");
        }
        if (imgBar.fillAmount < valStar1)
        {
            star1.color = new Color32(255, 255, 255, 100);
            starsWoned = 0;
            star1Anim.SetTrigger("LowPoints");
        }
        if (imgBar.fillAmount >= valStar1)
        {
            star1.color = new Color32(255, 255, 255, 255);
            starsWoned = 1;
            star1Anim.SetTrigger("HighPoints");
        }
        if (imgBar.fillAmount >= valStar2)
        {
            star2.color = new Color32(255, 255, 255, 255);
            starsWoned = 2;
            star2Anim.SetTrigger("HighPoints");
        }
        if (imgBar.fillAmount >= valStar3)
        {
            star3.color = new Color32(255, 255, 255, 255);
            starsWoned = 3;
            star3Anim.SetTrigger("HighPoints");
        }
    }
}
