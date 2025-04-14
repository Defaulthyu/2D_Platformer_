using UnityEngine;

public class OnewayEnemyController : MonoBehaviour
{
    public float movespeed = 3f;
    public Transform rootTransform; 
    public Transform flipTarget;    

    private Rigidbody2D rb;
    private bool isMovingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (flipTarget == null)
            flipTarget = this.transform; 
    }

    private void Update()
    {
        // 이동 처리
        float moveDirection = isMovingRight ? 1f : -1f;
        rb.velocity = new Vector2(moveDirection * movespeed, rb.velocity.y);

        // flipTarget (Skull)을 좌우 반전
        Vector3 scale = flipTarget.localScale;
        scale.x = isMovingRight ? 1f : -1f;
        flipTarget.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            isMovingRight = !isMovingRight;
        }
    }
}
