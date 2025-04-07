using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator myAnimator;
    public int speed = 5;
    private Rigidbody2D rb;

    void Start()
    {
        //myAnimator.SetBool("Move", false);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            myAnimator.SetBool("Move", true);
        }

        else if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            myAnimator.SetBool("Move", true);
        }
        else
            myAnimator.SetBool("Move", false);

        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(Vector2.up * 300);
        }
    }

 //   private void OnTriggerEnter2D(Collider2D collision)
 //   {
 //       UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene_" + collision.name);
 //   }
}

