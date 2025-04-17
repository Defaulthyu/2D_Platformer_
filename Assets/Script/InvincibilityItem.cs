using UnityEngine;

public class InvincibilityItem : MonoBehaviour
{
    public float invincibilityDuration = 5f;
    public AudioClip invincibilitySound; // �Ծ��� �� ����

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

                Destroy(gameObject); // �������� �������
            }
        }
    }
}
