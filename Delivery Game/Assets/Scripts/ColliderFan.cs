using Unity.VisualScripting;
using UnityEngine;

public class ColliderFan : MonoBehaviour
{
    public Transform selectedFan;
    public GameObject selectedTag;

    void Start()
    {
        selectedFan = this.transform;
        selectedTag = this.gameObject;
    }
    void OnMouseUp()
    {
        GameManager.Instance.moveObjectUI = selectedFan;
        GameManager.Instance.moveObjectTag = selectedTag;
    }
}
