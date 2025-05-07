using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBouncing : MonoBehaviour
{
    public Rigidbody2D rb_Player;
    public Transform tf_Player;
    public float force = 3;
    public Vector2 direction, reflectionDir;
    public bool rotation = true;
    public int moveDistance = 0;
    public Canvas canvasButtons;

    private void Start() {
        rb_Player = GameObject.Find("Delivery").GetComponent<Rigidbody2D>();
        tf_Player = GameObject.Find("Delivery").GetComponent<Transform>();
        reflectionDir = Vector2.right;
    }

    private void Update() {
            if(rotation == true && transform.rotation.z == 0) {
                reflectionDir = Vector2.right;
            }
            else if(rotation == false && transform.rotation.z == -90){
                reflectionDir = Vector2.left;
            }
            else if(rotation == true && transform.rotation.z == 180){
                reflectionDir = Vector2.left;
            }
            else if(rotation == false && transform.rotation.z == 90){
                reflectionDir = Vector2.right;
            }
        canvasButtons.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 0.366f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
            direction = Vector2.Reflect(tf_Player.position, reflectionDir);
            rb_Player.AddForce(direction * force, ForceMode2D.Impulse);
    }

    public void RotationSlime(){
        rotation = !rotation;
        transform.Rotate(0,0,-90);
    }
    public void MoveObjX(int moveX){
        transform.position = transform.position + new Vector3(moveX, 0);
    }
    public void MoveObjY(int moveY){
        transform.position = transform.position + new Vector3(0, moveY);
    }
}
