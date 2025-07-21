using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FadeDead : MonoBehaviour
{
    public bool startClosing = false;
    public float closeSpeed = 200f;
    public RectTransform maskTransform;
    public RawImage blackGroudOn;

    public void TriggerDeathFade(Vector2 worldPosition)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        maskTransform.position = screenPos;
        maskTransform.sizeDelta = new Vector2(18000f, 18000f);
        startClosing = true;
    }

    void Update()
    {
        if (startClosing)
        {
            float newSize = Mathf.Max(0, maskTransform.sizeDelta.x - closeSpeed * Time.deltaTime);
            maskTransform.sizeDelta = new Vector2(newSize, newSize);

            if (newSize <= 0)
            {
                GameManager.Instance.ReloadScene();
            }
        }
    }
}
