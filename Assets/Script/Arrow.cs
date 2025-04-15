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
            // TODO: �÷��̾� ������ �ֱ�
            Debug.Log("�÷��̾� ����!");
        }
        else if (collision.CompareTag("Obstacle") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
