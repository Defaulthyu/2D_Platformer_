using System.Collections;
using UnityEngine;

public class Fire_Trap : MonoBehaviour
{
    public GameObject fireEffect;      // �ٴ� ���� �ִ� �� ������Ʈ (Ȱ��/��Ȱ������ ON/OFF)
    public float fireOnTime = 1.5f;    // ���� �����ִ� �ð�
    public float fireOffTime = 2f;     // ���� �����ִ� �ð�

    private void Start()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
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
}
