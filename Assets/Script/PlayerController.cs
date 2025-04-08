using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator myAnimator;
    public float movespeed = 5f;
    public float jumpforce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        //myAnimator.SetBool("Move", false);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * movespeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

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

        //transform.Translate(Vector3.right * moveInput * movespeed * Time.deltaTime);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }

 //   private void OnTriggerEnter2D(Collider2D collision)
 //   {
 //       UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene_" + collision.name);
 //   }
}

