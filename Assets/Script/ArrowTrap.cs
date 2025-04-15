using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowPrefab;      // �߻��� ȭ�� ������
    public Transform firePoint;         // �߻� ��ġ

    [Header("�߻� ���� ����")]
    public float fireInterval = 2.0f;   // ȭ�� �߻� ���� (��)

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            FireArrow();        // ȭ�� �߻�
            timer = 0f;         // Ÿ�̸� �ʱ�ȭ
        }
    }

    void FireArrow()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
