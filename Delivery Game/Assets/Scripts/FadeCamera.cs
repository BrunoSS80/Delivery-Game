using UnityEngine;

public class FadeCamera : MonoBehaviour
{
    public Camera mainCamera, secundCamera  ;
    public float t, timeFade;
    public float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timeFade = elapsedTime / t;
    }
    public void FadeCameraCall()
    {
        mainCamera.depth = 0f;
        secundCamera.depth = 1f;
    }
}
