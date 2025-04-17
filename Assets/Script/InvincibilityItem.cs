using UnityEngine;

public class InvincibilityItem : MonoBehaviour
{
    public float invincibilityDuration = 5f;
    public AudioClip invincibilitySound; // 먹었을 때 사운드

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

                Destroy(gameObject); // 아이템은 사라진다
            }
        }
    }
}
