using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInMesh : MonoBehaviour
{
    public Rigidbody2D obj;
    private Vector2 mousePosition;
    private ActiveMenus activeMenus;
    void Start()
    {
        activeMenus = gameObject.GetComponentInChildren<ActiveMenus>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void OnMouseDrag() {
        if(activeMenus.menuOn == true){
        obj.transform.position = mousePosition;
        }
    }
}
