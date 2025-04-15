using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowPrefab;      // 발사할 화살 프리팹
    public Transform firePoint;         // 발사 위치

    [Header("발사 간격 설정")]
    public float fireInterval = 2.0f;   // 화살 발사 간격 (초)

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            FireArrow();        // 화살 발사
            timer = 0f;         // 타이머 초기화
        }
    }

    void FireArrow()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
