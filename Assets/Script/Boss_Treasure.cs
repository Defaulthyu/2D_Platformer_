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
    public AudioSource Crack;
    public AudioSource hitsound;

    public float cameraShakeDelay = 1f;
    public float bossAwakeDelay = 2f;
    public float playerFlyForce = 500f;
    public float sceneChangeDelay = 2f;
    public string nextSceneName = "Stage_5";

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
        if (playerAnimator != null)
            playerAnimator.SetTrigger("FindTreasure");

        // 2. 약간 대기
        yield return new WaitForSeconds(cameraShakeDelay);

        // 3. 카메라 흔들기
        if (impulseSource != null)
        {
            earthquake();
            impulseSource.GenerateImpulse();
            Debug.Log("카메라 흔들림");
        }

        // 5. 보스 사운드 재생
        if (bossSFX != null)
            Debug.Log("보스 사운드 재생");
            bossSFX.Play();

        // 4. 보스(석상) 깨어나는 애니메이션
        yield return new WaitForSeconds(bossAwakeDelay);
        if (bossAnimator != null)
            bossAnimator.SetTrigger("Awake");
        // Invoke("earthquake", 7.57f);





        // 7. 5스테이지로 씬 전환
        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene(nextSceneName);
    }
    private void earthquake()
    {
        if (Crack != null)
        {
            Crack.Play();
            Debug.Log("크랙 사운드 재생");
        }
    }
    private void hit()
    {
        if(hitsound != null)
        {
            hitsound.Play();
            Debug.Log("타격 사운드 재생");
        }
    }
}
