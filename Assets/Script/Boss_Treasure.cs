using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class BossEventManager : MonoBehaviour
{
    public Animator playerAnimator;
    public PlayerController playerController;
    public Rigidbody2D playerRb;
    public Animator bossAnimator;
    public CinemachineImpulseSource impulseSource;
    public AudioSource bossSFX;

    public float cameraShakeDelay = 1f;
    public float bossAwakeDelay = 2f;
    public float playerFlyForce = 500f;
    public float sceneChangeDelay = 2f;
    public string nextSceneName = "Stage5";

    private bool eventStarted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !eventStarted)
        {
            eventStarted = true;
            StartCoroutine(StartBossEvent());
        }
    }

    private IEnumerator StartBossEvent()
    {
        playerController.enabled = false; // 플레이어 이동 비활성화

        playerRb.velocity = Vector2.zero; // 플레이어 속도 초기화

        // 1. 플레이어 기뻐하는 애니메이션
        Debug.Log("플레이어 보물 찾음");
        if (playerAnimator != null)
            playerAnimator.SetTrigger("FindTreasure");

        // 2. 약간 대기
        yield return new WaitForSeconds(cameraShakeDelay);

        // 3. 카메라 흔들기
        if (impulseSource != null)
            impulseSource.GenerateImpulse();

        // 4. 보스(석상) 깨어나는 애니메이션
        yield return new WaitForSeconds(bossAwakeDelay);
        if (bossAnimator != null)
            bossAnimator.SetTrigger("Awake");


        // 5. 보스 사운드 재생
        if (bossSFX != null)
            bossSFX.Play();

        // 6. 플레이어 날리기
        yield return new WaitForSeconds(0.5f);
        if (playerRb != null)
        {
            playerAnimator.SetTrigger("PlayerThrow");
        }

        // 7. 5스테이지로 씬 전환
        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene(nextSceneName);
    }
}
