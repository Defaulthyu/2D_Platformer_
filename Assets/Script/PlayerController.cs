using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Awake()
    {
        //myAnimator.SetBool("Move", false);
        rb = GetComponent<Rigidbody2D>();
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

        private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        }
    }
}


