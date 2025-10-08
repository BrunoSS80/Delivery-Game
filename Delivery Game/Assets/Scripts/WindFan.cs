using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindFan : MonoBehaviour
{
    public float windForce = 1f;
    public Vector2 windDirection;
    public Transform fan;

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (fan.transform.localRotation.eulerAngles.z <= 0)
            {
                windDirection = new Vector2(0, 1);
            }
            else if (fan.transform.localRotation.eulerAngles.z <= 45)
            {
                windDirection = new Vector2(-1, 1);
            }
            else if (fan.transform.localRotation.eulerAngles.z <= 90)
            {
                windDirection = new Vector2(-1, 0);
            }
            else if (fan.transform.localRotation.eulerAngles.z <= 135)
            {
                windDirection = new Vector2(-1, -1);
            }
            else if (fan.transform.localRotation.eulerAngles.z <= 180)
            {
                windDirection = new Vector2(0, -1);
            }
            else if (fan.transform.localRotation.eulerAngles.z <= 225)
            {
                windDirection = new Vector2(1, -1);
            }
            else if (fan.transform.localRotation.eulerAngles.z <= 270)
            {
                windDirection = new Vector2(1, 0);
            }
            else if (fan.transform.localRotation.eulerAngles.z <= 315)
            {
                windDirection = new Vector2(1, 1);
            }
        rb.AddForce(windDirection.normalized * windForce, ForceMode2D.Impulse);
        }
    }
}
