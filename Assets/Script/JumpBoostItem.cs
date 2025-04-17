using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpBoostItem : MonoBehaviour
{
    public float boostAmount = 14f; // ��Һ��� �� �� ���� ����
    public float duration = 5f; // ȿ�� ���� �ð�
    public AudioClip jumpBoostSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("���� �ν�Ʈ ������ ȹ��");
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {

                player.ApplyJumpBoost(boostAmount, duration);

                //AudioSource.PlayClipAtPoint(jumpBoostSound, transform.position);

                Destroy(gameObject); // �������� 1ȸ��
            }
        }
    }
}
