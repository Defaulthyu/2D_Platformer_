using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    public float invincibleTime = 1.0f;
    public bool isInvincible = false;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentLives = maxLives;
        animator = GetComponentInChildren<Animator>(); // ��Ʈ ������ �ִϸ����Ͱ� �ִ� ���
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Arrow") || !isInvincible)
        {
            currentLives--;
            Destroy(other.gameObject);
            StartCoroutine(Invincibility());

            if (currentLives <= 0)
            {
                DieByArrow();
            }
        }

        if (other.CompareTag("Lava"))
        {
            DieByLava();
        }
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    void DieByArrow()
    {
        if (animator != null)
        {
            animator.SetTrigger("DieByArrow");
        }
        else
        {
            Debug.LogWarning("Animator component not found.");
        }

        DisablePlayer();
        Invoke("RestartGame", 2.5f); // �ִϸ��̼� ��� �ð���ŭ ������ ��
    }

    void DieByLava()
    {
        if (isDead) return; // �� �� ���� �ʵ���

        if (animator != null)
        {
            animator.SetTrigger("DieByLava");
        }
        else
        {
            Debug.LogWarning("Animator component not found.");
        }

        DisablePlayer();
        Invoke("RestartGame", 0.49f); // Lava �ִϸ��̼� �ð���ŭ ����
    }

    void DisablePlayer()
    {
        isDead = true;
        GetComponent<PlayerController>().enabled = false; // ������ ����
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
