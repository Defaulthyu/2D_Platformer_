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
        animator = GetComponentInChildren<Animator>(); // 루트 하위에 애니메이터 있는 경우

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        //  화살 맞음
        if (other.CompareTag("Arrow"))
        {
            if (!isInvincible)
            {
                currentLives--;
                Destroy(other.gameObject); // 화살 제거

                if (currentLives <= 0)
                {
                    DieByArrow();
                }
            }
            else
            {
                Destroy(other.gameObject); // 화살 제거
            }

        }

        // 용암 닿음
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
        else if (other.CompareTag("Trap"))
        {
            if (!isInvincible)
            {
                if (animator != null)
                {

                    animator.SetTrigger("HitByTrap");
                }
                currentLives--;
                HitByTrap();

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

    void HitByTrap()
    {
        if (isDead) return;
        
        if (currentLives <= 0)
        {
            RestartGame();
        }
        else
        


        DisablePlayer();
        Invoke("EnablePlayer", 1f);
        Invoke("Move", 1f);

    }

    void DisablePlayer()
    {
        isDead = true;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        
    }

    void EnablePlayer()
    {
        isDead = false;
        GetComponent<PlayerController>().enabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Move()
    {
        if (animator != null)
        {
            animator.SetBool("Move", true);
        }
    }
}

