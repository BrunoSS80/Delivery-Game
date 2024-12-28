using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMenus : MonoBehaviour
{
    public Canvas canvas;
    public bool menuOn = false;
    
    private void OnMouseUp() {
        canvas.enabled = !canvas.enabled;

        if(canvas.enabled == true){
            menuOn = true;
        }
        else{
            menuOn = false;
        }
    }
}
