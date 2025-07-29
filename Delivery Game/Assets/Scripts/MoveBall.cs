using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Rigidbody2D rb_Ball;
    public float force;
    public Transform moveForce, maxForce;
    public Vector3 direction, scanPos, screenPoint, offset;
    void Start()
    {
        rb_Ball = GetComponent<Rigidbody2D>();
    }
    private void Update() {
    }
    
    private void OnMouseDown() {
        scanPos = moveForce.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //offset = Camera.main.ScreenToWorldPoint(maxForce.transform.position);
    }

    private void OnMouseDrag()
    {
        screenPoint = scanPos + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveForce.transform.position = screenPoint;
        //Vector3 force = screenPoint - offset;
        force = Vector3.Distance(moveForce.transform.position, transform.position);
        Debug.Log(transform.position + "," + force);
        //force *= 1.08f;
        if (force > maxForce.transform.localPosition.magnitude)
        {
            force = 3;
        }
        direction.x = Mathf.Clamp(moveForce.transform.localPosition.x, -4.5f, 4.5f);
        direction.y = Mathf.Clamp(moveForce.transform.localPosition.y, -4.5f, 4.5f);
        //direction = moveForce.transform.position;
        /*if (moveForce.transform.position.y > maxForce.transform.position.y)
        {
            direction = moveForce.transform.position;
        }*/
        /*else if (moveForce.transform.position.y <= maxForce.transform.position.y)
        {
            direction.y = maxForce.transform.position.y;
        }*/
    }

    private void OnMouseUp() {
        rb_Ball.AddForce(-direction * force, ForceMode2D.Impulse);
        //direction = Vector3.zero;
        moveForce.transform.position = transform.position;
    }
}
