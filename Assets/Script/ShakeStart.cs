using UnityEngine;

public class Stage5Manager : MonoBehaviour
{
    public CameraShake cameraShake;

    void Start()
    {
        if (cameraShake != null)
        {
            cameraShake.StartShake();
            Debug.Log("��鸲"); // �������� �����ϸ� ī�޶� ��鸮��!
        }
    }
}
