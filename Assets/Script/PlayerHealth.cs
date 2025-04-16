using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentLives = maxLives;
        animator = GetComponentInChildren<Animator>(); // 루트 하위에 애니메이터 있는 경우
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        //  화살 맞음
        if (other.CompareTag("Arrow"))
        {
            currentLives--;
            Destroy(other.gameObject); // 화살 제거

            if (currentLives <= 0)
            {
                DieByArrow();
            }
        }

        // 용암 닿음
        if (other.CompareTag("Lava"))
        {
            DieByLava();
        }

        if (other.CompareTag("Skeleton"))
        {
            DieBySkeleton();
        }

    }

    void DieByArrow()
    {
        if (animator != null)
        {
            animator.SetTrigger("DieByArrow");
        }

        DisablePlayer();
        Invoke("RestartGame", 2.5f);
    }

    void DieByLava()
    {
        if (isDead) return;

        if (animator != null)
        {
            animator.SetTrigger("DieByLava");
        }

        DisablePlayer();
        Invoke("RestartGame", 0.49f);
    }

    void DieBySkeleton()
    {
        if (isDead) return;
        if (animator != null)
        {
            animator.SetTrigger("DieBySkeleton");
        }
        DisablePlayer();
        Invoke("RestartGame", 1.21f);
    }

    void DisablePlayer()
    {
        isDead = true;
        GetComponent<PlayerController>().enabled = false;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
