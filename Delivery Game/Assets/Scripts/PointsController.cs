using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    public float valFan, valSlime;
    public Image imgBar;

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
            imgBar.fillAmount += valSlime;
        }
        else
        {
            imgBar.fillAmount += valFan;
        }
        GameManager.Instance.moveObjectTag.SetActive(false);
        GameManager.Instance.moveObjectTag = null;
        GameManager.Instance.moveObjectUI = null;
    
    }
}
