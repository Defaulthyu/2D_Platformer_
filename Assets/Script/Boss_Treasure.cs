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
        playerController.enabled = false; // �÷��̾� �̵� ��Ȱ��ȭ

        playerRb.velocity = Vector2.zero; // �÷��̾� �ӵ� �ʱ�ȭ

        // 1. �÷��̾� �⻵�ϴ� �ִϸ��̼�
        Debug.Log("�÷��̾� ���� ã��");
        if (playerAnimator != null)
            playerAnimator.SetTrigger("FindTreasure");

        // 2. �ణ ���
        yield return new WaitForSeconds(cameraShakeDelay);

        // 3. ī�޶� ����
        if (impulseSource != null)
            impulseSource.GenerateImpulse();

        // 4. ����(����) ����� �ִϸ��̼�
        yield return new WaitForSeconds(bossAwakeDelay);
        if (bossAnimator != null)
            bossAnimator.SetTrigger("Awake");


        // 5. ���� ���� ���
        if (bossSFX != null)
            bossSFX.Play();

        // 6. �÷��̾� ������
        yield return new WaitForSeconds(0.5f);
        if (playerRb != null)
        {
            playerAnimator.SetTrigger("PlayerThrow");
        }

        // 7. 5���������� �� ��ȯ
        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene(nextSceneName);
    }
}
