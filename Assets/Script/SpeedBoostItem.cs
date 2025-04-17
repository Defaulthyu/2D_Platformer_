using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostAmount = 1.5f;   // 1.5�� ������
    public float boostDuration = 5f;   // 5�� ����

    public Image speedBoostImage; // UI���� �ӵ� ���� �������� ǥ���� �̹���
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

            GetComponent<Collider2D>().enabled = false; // �������� ���� �� �浹ü�� ��Ȱ��ȭ
            GetComponent<SpriteRenderer>().enabled = false; // �������� ���� �� ��������Ʈ�� ��Ȱ��ȭ

            StartCoroutine(ShowSpeedBoostUI());


        }
    }
    private IEnumerator ShowSpeedBoostUI()
    {
        // 1. �̹��� Ȱ��ȭ
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
