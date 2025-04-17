using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    private Animator animator;
    private bool isDead = false;

    public bool isInvincible = false;

    void Start()
    {
        currentLives = maxLives;
        animator = GetComponentInChildren<Animator>(); // ��Ʈ ������ �ִϸ����� �ִ� ���
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        //  ȭ�� ����
        if (other.CompareTag("Arrow"))
        {
            if (!isInvincible)
            {
                currentLives--;
                Destroy(other.gameObject); // ȭ�� ����

                if (currentLives <= 0)
                {
                    DieByArrow();
                }
            }
            else
            {
                Destroy(other.gameObject); // ȭ�� ����
            }

        }

        // ��� ����
        else if (other.CompareTag("Lava"))
        {
            DieByLava();
        }

        else if (other.CompareTag("Skeleton"))
        {
            if(!isInvincible)
            {
                DieBySkeleton();
            }
        }
        else if (other.CompareTag("Fire"))
        {
            if(!isInvincible)
            {
                DieByFire();
            }
        }

    }

    public void ActivateInvincibility(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
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
        Invoke("RestartGame", 0.5f);
    }

    void DieBySkeleton()
    {
        if (isDead) return;
        if (animator != null)
        {
            animator.SetTrigger("DieBySkeleton");
        }
        DisablePlayer();
        Invoke("RestartGame", 3f);
    }

    void DieByFire()
    {
        if (isDead) return;

        if (animator != null)
        {
            animator.SetTrigger("DieByFire");
        }

        DisablePlayer();
        Invoke("RestartGame", 1f);
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
