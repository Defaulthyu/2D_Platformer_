using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class InvincibilityItem : MonoBehaviour
{
    public float invincibilityDuration = 5f;
    public AudioClip invincibilitySound; // �Ծ��� �� ����
    public Image invincibilityImage; // UI���� ���� �������� ǥ���� �̹���
    public TMP_Text invincibilityTimerText; // UI���� ���� Ÿ�̸Ӹ� ǥ���� �ؽ�Ʈ


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.ActivateInvincibility(invincibilityDuration);

                // ���� ���
                if (invincibilitySound != null)
                {
                    AudioSource.PlayClipAtPoint(invincibilitySound, transform.position);
                }

            }

            GetComponent<Collider2D>().enabled = false; // �������� ���� �� �浹ü�� ��Ȱ��ȭ
            GetComponent<SpriteRenderer>().enabled = false; // �������� ���� �� ��������Ʈ�� ��Ȱ��ȭ

            StartCoroutine(UI());
        }
    }


    private IEnumerator UI()
    {
        // 1. �̹��� Ȱ��ȭ
        if (invincibilityImage != null)
            invincibilityImage.gameObject.SetActive(true);
        if (invincibilityTimerText != null)
            invincibilityTimerText.gameObject.SetActive(true);
        float Timer = invincibilityDuration;
        while (Timer > 0f)
        {
            if (invincibilityTimerText != null)
                invincibilityTimerText.text = Timer.ToString("0.0");
            yield return new WaitForSeconds(0.1f);
            Timer -= 0.1f;
        }
        // 2. �̹��� ��Ȱ��ȭ
        if (invincibilityImage != null)
            invincibilityImage.gameObject.SetActive(false);
        if (invincibilityTimerText != null)
            invincibilityTimerText.gameObject.SetActive(false);

        Destroy(gameObject);
    }
}
