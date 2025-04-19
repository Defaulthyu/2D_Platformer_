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
        playerController.enabled = false; // �÷��̾� �̵� ��Ȱ��ȭ

        playerRb.velocity = Vector2.zero; // �÷��̾� �ӵ� �ʱ�ȭ

        // 1. �÷��̾� �⻵�ϴ� �ִϸ��̼�
        if (playerAnimator != null)
            playerAnimator.SetTrigger("FindTreasure");

        // 2. �ణ ���
        yield return new WaitForSeconds(cameraShakeDelay);

        // 3. ī�޶� ����
        if (impulseSource != null)
        {
            earthquake();
            impulseSource.GenerateImpulse();
            Debug.Log("ī�޶� ��鸲");
        }

        // 5. ���� ���� ���
        if (bossSFX != null)
            Debug.Log("���� ���� ���");
            bossSFX.Play();

        // 4. ����(����) ����� �ִϸ��̼�
        yield return new WaitForSeconds(bossAwakeDelay);
        if (bossAnimator != null)
            bossAnimator.SetTrigger("Awake");
        // Invoke("earthquake", 7.57f);





        // 7. 5���������� �� ��ȯ
        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene(nextSceneName);
    }
    private void earthquake()
    {
        if (Crack != null)
        {
            Crack.Play();
            Debug.Log("ũ�� ���� ���");
        }
    }
    private void hit()
    {
        if(hitsound != null)
        {
            hitsound.Play();
            Debug.Log("Ÿ�� ���� ���");
        }
    }
}
