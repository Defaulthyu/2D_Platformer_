using UnityEngine;
using UnityEngine.Tilemaps;

public class BossChase : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float chaseSpeed = 3f;

    private void Start()
    {
        if (animator != null)
            animator.SetBool("Walk", true);

        if (rb != null)
            rb.freezeRotation = true; // Z축 회전 고정
    }

    private void FixedUpdate()
    {
        if (rb != null)
            rb.velocity = new Vector2(chaseSpeed, rb.velocity.y); // 무조건 달리기
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();

            if (tilemap != null)
            {
                foreach (ContactPoint2D hit in collision.contacts)
                {
                    Vector3 hitPos = Vector3.zero;
                    hitPos.x = hit.point.x - 0.01f * hit.normal.x;
                    hitPos.y = hit.point.y - 0.01f * hit.normal.y;

                    Vector3Int cellPosition = tilemap.WorldToCell(hitPos);
                    tilemap.SetTile(cellPosition, null); // 타일 하나 부수기
                }
            }
        }
    }
}
