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

        else if (other.CompareTag("Moai"))
        {
            DieByMoai();
        }

        // 용암 닿음
        else if (other.CompareTag("Lava"))
        {
            DieByLava();
        }

        else if (other.CompareTag("Skeleton"))
        {
            if (!isInvincible)
            {
                DieBySkeleton();
            }
        }
        else if (other.CompareTag("Fire"))
        {
            if (!isInvincible)
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
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; // 플레이어 속도 초기화
            DeathSound();
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
            DeathSound();
            animator.SetTrigger("DieByLava");
        }

        DisablePlayer2();
        Invoke("RestartGame", 0.5f);
    }

    void DieBySkeleton()
    {
        if (isDead) return;
        if (animator != null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; // 플레이어 속도 초기화
            DeathSound();
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
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; // 플레이어 속도 초기화
            DeathSound();
            animator.SetTrigger("DieByFire");
        }
        DisablePlayer2();
        Invoke("RestartGame", 1f);
    }

    void DieByMoai()
    {
        if (isDead) return;
        if (animator != null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; // 플레이어 속도 초기화
            DeathSound();
            animator.SetTrigger("DieByMoai");
        }
        DisablePlayer();

        Invoke("RestartGame", 1.5f);
    }

    void HitByTrap()
    {
        if (isDead) return;
        

        else
        


        DisablePlayer();
        Invoke("EnablePlayer", 1f);
        Invoke("Move", 1f);

        if (currentLives <= 0)
        {
            DeathSound();
            Invoke("RestartGame", 1f);
        }

    }

    void DisablePlayer()
    {
        isDead = true;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        
    }

    void DeathSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void EnablePlayer()
    {
        isDead = false;
        GetComponent<PlayerController>().enabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void EnablePlayer2()
    {
        isDead = false;
        GetComponent<PlayerController>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    void DisablePlayer2()
    {
        isDead = true;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
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

