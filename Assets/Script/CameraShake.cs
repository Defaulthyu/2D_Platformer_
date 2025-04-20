using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    private CinemachineBasicMultiChannelPerlin noise;

    public float shakeAmplitude = 2f;
    public float shakeFrequency = 2f;
    public float shakeDuration = 0.5f;

    private float shakeTimer;

    void Start()
    {
        noise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0f)
            {
                StopShake();
            }
        }
    }

    public void StartShake()
    {
        if (noise == null) return;

        noise.m_AmplitudeGain = shakeAmplitude;
        noise.m_FrequencyGain = shakeFrequency;
        shakeTimer = shakeDuration;
    }

    public void StopShake()
    {
        if (noise == null) return;

        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
    }
}
