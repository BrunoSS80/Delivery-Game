using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlimeBouncing : MonoBehaviour
{
    public Rigidbody2D rb_Player;
    public Transform tf_Player;
    public Transform slime_Block;
    public float force = 2;
    public bool rot1, rot2, rot3, rot4;
    private Vector3 direction;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Bateu");
        if(rot1 == true){
            //direction = new Vector3(-1, 1, 0);
            direction = Vector3.Reflect(tf_Player.position, Vector3.right);
            //direction = slime_Block.position;
            rb_Player.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}
