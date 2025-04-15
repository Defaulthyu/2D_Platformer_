using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // TODO: 플레이어 데미지 주기
            Debug.Log("플레이어 맞음!");
        }
        else if (collision.CompareTag("Obstacle") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
