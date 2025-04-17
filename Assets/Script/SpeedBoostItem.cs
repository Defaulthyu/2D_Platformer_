using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostAmount = 1.5f;   // 1.5�� ������
    public float boostDuration = 5f;   // 5�� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.BoostMoveSpeed(boostAmount, boostDuration);
            }
            Destroy(gameObject);
        }
    }
}
