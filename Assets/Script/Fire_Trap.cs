using System.Collections;
using UnityEngine;

public class Fire_Trap : MonoBehaviour
{
    public GameObject fireEffect;      // 바닥 위에 있는 불 오브젝트 (활성/비활성으로 ON/OFF)
    public float fireOnTime = 1.5f;    // 불이 켜져있는 시간
    public float fireOffTime = 2f;     // 불이 꺼져있는 시간
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
            // 불 켜기
            fireEffect.SetActive(true);

            yield return new WaitForSeconds(fireOnTime);

            // 불 끄기
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
