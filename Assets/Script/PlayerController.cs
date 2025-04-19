using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator myAnimator;
    public float movespeed = 5f;
    public float jumpforce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGrounded;

    private int jumpCount = 0;
    private bool hasSpring = false;

    private float originalJumpForce;

    public Image Spring;
    public Image JumpBoostImage;
    public Image SpeedBoostImage;
    public TMP_Text JumpBoostTimerText;
    public TMP_Text SpeedBoostTimerText;


    private void Start()
    {
        if (Spring != null)
            Spring.enabled = false;
        if (JumpBoostImage != null)
            JumpBoostImage.enabled = false;
        if (SpeedBoostImage != null)
            SpeedBoostImage.enabled = false;
        if (JumpBoostTimerText != null)
            JumpBoostTimerText.gameObject.SetActive(false);
        if (SpeedBoostTimerText != null)
            SpeedBoostTimerText.gameObject.SetActive(false);
    }

    private void Awake()
    {
        originalJumpForce = jumpforce;
        //myAnimator.SetBool("Move", false);
        rb = GetComponent<Rigidbody2D>();
    }
    public void ApplyJumpBoost(float BoostAmount, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(JumpBoostRoutine(BoostAmount, duration));
    }

    IEnumerator JumpBoostRoutine(float BoostAmount, float duration)
    {
        jumpforce = BoostAmount;
        yield return new WaitForSeconds(duration);
        jumpforce = originalJumpForce;
    }

    public void BoostMoveSpeed(float boostAmount, float duration)
    {
        StartCoroutine(SpeedBoost(boostAmount, duration));
    }

    IEnumerator SpeedBoost(float boostAmount, float duration)
    {
        float originalSpeed = movespeed;
        float originalAnimspeed = myAnimator.speed;

        movespeed *= boostAmount;
        myAnimator.speed *= boostAmount;
        yield return new WaitForSeconds(duration);
        movespeed = originalSpeed;
        myAnimator.speed = originalAnimspeed;
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * movespeed, rb.velocity.y);


        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            myAnimator.SetBool("Move", true);
        }

        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            myAnimator.SetBool("Move", true);
        }
        else
            myAnimator.SetBool("Move", false);

        bool wasGrounded = isGrounded;
        

        //transform.Translate(Vector3.right * moveInput * movespeed * Time.deltaTime);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if(!wasGrounded && isGrounded)
        {
            jumpCount = 0;
        }

        int maxJump = hasSpring ? 2 : 1;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            jumpCount++;
        }

        myAnimator.SetBool("Jump", !isGrounded);


    }

    private void spring()
    {
        if (Spring != null)
        Spring.enabled = true;



    }

        private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Respawn"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }
        if(collision.CompareTag("Spring"))
        {
            Debug.Log("½ºÇÁ¸µ È¹µæ");
            hasSpring = true;
            jumpCount = 0;
            Destroy(collision.gameObject);
            spring();
        }
    }
}


