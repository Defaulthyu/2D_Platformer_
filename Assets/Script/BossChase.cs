using UnityEngine;
using UnityEngine.Tilemaps;

public class BossChase : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float chaseSpeed = 3f;

    void Update()
    {
        rb.velocity = new Vector2(chaseSpeed, rb.velocity.y);
        animator.SetBool("Walk", true); // °è¼Ó °È±â
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();
            if (tilemap != null)
            {
                foreach (ContactPoint2D contact in collision.contacts)
                {
                    Vector3 hitPoint = contact.point;
                    Vector3Int cell = tilemap.WorldToCell(hitPoint);

                    // ºÎµúÈù ¼¿°ú ÁÖº¯ 8Ä­µµ °°ÀÌ ºÎ½¤ÁØ´Ù
                    for (int x = -2; x <= 2; x++)
                    {
                        for (int y = -3; y <= 3; y++)
                        {
                            Vector3Int offsetCell = new Vector3Int(cell.x + x, cell.y + y, cell.z);
                            if (tilemap.HasTile(offsetCell))
                            {
                                tilemap.SetTile(offsetCell, null);
                            }
                        }
                    }
                }
            }
        }
        else if (collision.gameObject.CompareTag("Trap2"))
        {
            Destroy(collision.gameObject); // ÇÔÁ¤ »èÁ¦
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.DieByMoai();
            }
        }
    }
}
