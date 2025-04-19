using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JumpBoostItem : MonoBehaviour
{
    public float boostAmount = 14f; // 평소보다 두 배 높이 점프
    public float duration = 5f; // 효과 지속 시간
    public AudioClip jumpBoostSound;

    public Image jumpBoostImage; // UI에서 점프 증가 아이콘을 표시할 이미지
    public TMP_Text jumpBoostTimerText;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("점프 부스트 아이템 획득");
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplyJumpBoost(boostAmount, duration);

                AudioSource.PlayClipAtPoint(jumpBoostSound, transform.position);                                
            }

            GetComponent<Collider2D>().enabled = false; // 아이템을 먹은 후 충돌체를 비활성화
            GetComponent<SpriteRenderer>().enabled = false; // 아이템을 먹은 후 스프라이트를 비활성화

            StartCoroutine(ShowJumpBoostUI() );
        }
    }

    private IEnumerator ShowJumpBoostUI()
    {
        // 1. 이미지 활성화
        if (jumpBoostImage != null)
            jumpBoostImage.enabled = true;
        if (jumpBoostTimerText != null)
            jumpBoostTimerText.gameObject.SetActive(true);
        float Timer = duration;
        while (Timer > 0f)
        {
            if (jumpBoostTimerText != null)
                jumpBoostTimerText.text = Timer.ToString("0.0");
            yield return new WaitForSeconds(0.1f);
            Timer -= 0.1f;
        }
        // 2. 이미지 비활성화
        if (jumpBoostImage != null)
            jumpBoostImage.enabled = false;
        if (jumpBoostTimerText != null)
            jumpBoostTimerText.gameObject.SetActive(false);

        Destroy(gameObject);
    }
}
