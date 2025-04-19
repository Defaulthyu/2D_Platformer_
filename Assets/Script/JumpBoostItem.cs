using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JumpBoostItem : MonoBehaviour
{
    public float boostAmount = 14f; // ��Һ��� �� �� ���� ����
    public float duration = 5f; // ȿ�� ���� �ð�
    public AudioClip jumpBoostSound;

    public Image jumpBoostImage; // UI���� ���� ���� �������� ǥ���� �̹���
    public TMP_Text jumpBoostTimerText;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("���� �ν�Ʈ ������ ȹ��");
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplyJumpBoost(boostAmount, duration);

                AudioSource.PlayClipAtPoint(jumpBoostSound, transform.position);                                
            }

            GetComponent<Collider2D>().enabled = false; // �������� ���� �� �浹ü�� ��Ȱ��ȭ
            GetComponent<SpriteRenderer>().enabled = false; // �������� ���� �� ��������Ʈ�� ��Ȱ��ȭ

            StartCoroutine(ShowJumpBoostUI() );
        }
    }

    private IEnumerator ShowJumpBoostUI()
    {
        // 1. �̹��� Ȱ��ȭ
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
        // 2. �̹��� ��Ȱ��ȭ
        if (jumpBoostImage != null)
            jumpBoostImage.enabled = false;
        if (jumpBoostTimerText != null)
            jumpBoostTimerText.gameObject.SetActive(false);

        Destroy(gameObject);
    }
}
