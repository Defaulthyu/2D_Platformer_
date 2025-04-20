using UnityEngine;

public class Stage5Manager : MonoBehaviour
{
    public CameraShake cameraShake;

    void Start()
    {
        if (cameraShake != null)
        {
            cameraShake.StartShake();
            Debug.Log("흔들림"); // 스테이지 시작하면 카메라 흔들리기!
        }
    }
}
