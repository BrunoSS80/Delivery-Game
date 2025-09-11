using UnityEngine;

public class GridScript : MonoBehaviour
{
    void OnMouseUp()
    {
        GameManager.Instance.moveObjectTag = null;
        GameManager.Instance.moveObjectUI = null;
    }
}
