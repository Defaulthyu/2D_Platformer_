using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class InvincibilityItem : MonoBehaviour
{
    public float invincibilityDuration = 5f;
    public AudioClip invincibilitySound; // 먹었을 때 사운드
    public Image invincibilityImage; // UI에서 무적 아이콘을 표시할 이미지
    public TMP_Text invincibilityTimerText; // UI에서 무적 타이머를 표시할 텍스트


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.ActivateInvincibility(invincibilityDuration);

                // 사운드 재생
                if (invincibilitySound != null)
                {
                    AudioSource.PlayClipAtPoint(invincibilitySound, transform.position);
                }

            }

            GetComponent<Collider2D>().enabled = false; // 아이템을 먹은 후 충돌체를 비활성화
            GetComponent<SpriteRenderer>().enabled = false; // 아이템을 먹은 후 스프라이트를 비활성화

            StartCoroutine(UI());
        }
    }


    private IEnumerator UI()
    {
        // 1. 이미지 활성화
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
        // 2. 이미지 비활성화
        if (invincibilityImage != null)
            invincibilityImage.gameObject.SetActive(false);
        if (invincibilityTimerText != null)
            invincibilityTimerText.gameObject.SetActive(false);

        Destroy(gameObject);
    }
}
