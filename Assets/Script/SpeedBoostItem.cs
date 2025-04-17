using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostAmount = 1.5f;   // 1.5배 빠르게
    public float boostDuration = 5f;   // 5초 동안

    public Image speedBoostImage; // UI에서 속도 증가 아이콘을 표시할 이미지
    public TMP_Text speedBoostTimerText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.BoostMoveSpeed(boostAmount, boostDuration);
            }

            GetComponent<Collider2D>().enabled = false; // 아이템을 먹은 후 충돌체를 비활성화
            GetComponent<SpriteRenderer>().enabled = false; // 아이템을 먹은 후 스프라이트를 비활성화

            StartCoroutine(ShowSpeedBoostUI());


        }
    }
    private IEnumerator ShowSpeedBoostUI()
    {
        // 1. 이미지 활성화
        if (speedBoostImage != null)
            speedBoostImage.enabled = true;


        if (speedBoostTimerText != null)
            speedBoostTimerText.gameObject.SetActive(true);

        float Timer = boostDuration;

        while (Timer > 0f)
        {
            if (speedBoostTimerText != null)
                speedBoostTimerText.text = Timer.ToString("0.0");

            yield return new WaitForSeconds(0.1f);
            Timer -= 0.1f;
        }

        if(speedBoostImage != null)
            speedBoostImage.enabled = false;

        if(speedBoostTimerText != null)
            speedBoostTimerText.gameObject.SetActive(false);

        Destroy(gameObject);
    }
}
