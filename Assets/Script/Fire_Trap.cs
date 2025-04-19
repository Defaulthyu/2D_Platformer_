using System.Collections;
using UnityEngine;

public class Fire_Trap : MonoBehaviour
{
    public GameObject fireEffect;      // �ٴ� ���� �ִ� �� ������Ʈ (Ȱ��/��Ȱ������ ON/OFF)
    public float fireOnTime = 1.5f;    // ���� �����ִ� �ð�
    public float fireOffTime = 2f;     // ���� �����ִ� �ð�
    public float WaitTime = 0.5f;



    private void Start()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        yield return new WaitForSeconds(WaitTime);
        while (true)
        {
            // �� �ѱ�
            fireEffect.SetActive(true);

            yield return new WaitForSeconds(fireOnTime);

            // �� ����
            fireEffect.SetActive(false);

            yield return new WaitForSeconds(fireOffTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moai"))
        {
            Destroy(gameObject);
        }
    }
}
