using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpBoostItem : MonoBehaviour
{
    public float boostAmount = 14f; // 평소보다 두 배 높이 점프
    public float duration = 5f; // 효과 지속 시간
    public AudioClip jumpBoostSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("점프 부스트 아이템 획득");
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {

                player.ApplyJumpBoost(boostAmount, duration);

                //AudioSource.PlayClipAtPoint(jumpBoostSound, transform.position);

                Destroy(gameObject); // 아이템은 1회용
            }
        }
    }
}
