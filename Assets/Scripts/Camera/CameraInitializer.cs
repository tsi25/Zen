using UnityEngine;
using System.Collections;

public class CameraInitializer : MonoBehaviour
{
    public Camera leftCamera;
    public Camera rightCamera;

    public Vector2 leftCameraOffset = Vector2.zero;
    public Vector2 leftCameraScale = new Vector2(0.5f, 1f);

    public Vector2 rightCameraOffset = new Vector2(0.5f, 0f);
    public Vector2 rightCameraScale = new Vector2(0.5f, 1f);


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        leftCamera.rect = new Rect(leftCameraOffset.x, leftCameraScale.x, leftCameraOffset.y, leftCameraScale.y);
        rightCamera.rect = new Rect(rightCameraOffset.x, rightCameraScale.x, rightCameraOffset.y, rightCameraScale.y);
    }
}
