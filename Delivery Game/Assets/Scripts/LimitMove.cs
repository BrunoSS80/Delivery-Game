using UnityEngine;

public class LimitMove : MonoBehaviour
{
    public Transform objMoving;

    void Start()
    {
        objMoving = this.transform;
    }
    void Update()
    {
        if (objMoving.transform.position.y >= 9)
        {
            objMoving.transform.position = new Vector2(objMoving.transform.position.x, 8);
        }
        else if (objMoving.transform.position.y <= -9)
        {
            objMoving.transform.position = new Vector2(objMoving.transform.position.x, -8);
        }

        if (objMoving.transform.position.x >= 5)
        {
            objMoving.transform.position = new Vector2(4, objMoving.transform.position.y);
        }
        else if (objMoving.transform.position.x <= -5)
        {
            objMoving.transform.position = new Vector2(-4, objMoving.transform.position.y);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (GameManager.Instance.editMode)
        {
            GameManager.Instance.editBt.interactable = false;
            GameManager.Instance.confirmBt.interactable = false;
            MeshCollider meshGrid = GameManager.Instance.grid.GetComponent<MeshCollider>();
            meshGrid.enabled = false;
        }
    }
    

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && GameManager.Instance.confirmBt != null && GameManager.Instance.editMode)
        {
            GameManager.Instance.editBt.interactable = true;
            GameManager.Instance.confirmBt.interactable = true;
            MeshCollider meshGrid = GameManager.Instance.grid.GetComponent<MeshCollider>();
            meshGrid.enabled = true;
        }
    }
}
