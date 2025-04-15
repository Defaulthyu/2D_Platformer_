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
        animator = GetComponentInChildren<Animator>(); // 루트 하위에 애니메이터가 있는 경우
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
        Invoke("RestartGame", 2.5f); // 애니메이션 재생 시간만큼 여유를 줘
    }

    void DieByLava()
    {
        if (isDead) return; // 두 번 죽지 않도록

        if (animator != null)
        {
            animator.SetTrigger("DieByLava");
        }
        else
        {
            Debug.LogWarning("Animator component not found.");
        }

        DisablePlayer();
        Invoke("RestartGame", 0.49f); // Lava 애니메이션 시간만큼 조절
    }

    void DisablePlayer()
    {
        isDead = true;
        GetComponent<PlayerController>().enabled = false; // 움직임 차단
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
