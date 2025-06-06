using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public PlayerHealth playerhealth;

    private void Awake()
    {
        if(playerhealth == null)
        {
            playerhealth = FindObjectOfType<PlayerHealth>();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            if (!playerhealth.isInvincible)
            {
                if (hp3.activeSelf == true)
                {
                    hp3.SetActive(false);
                }
                else if (hp2.activeSelf == true)
                {
                    hp2.SetActive(false);
                }
                else if (hp1.activeSelf == true)
                {
                    hp1.SetActive(false);
                }
            }
        }
        if (other.CompareTag("Lava"))
        {
            hp3.SetActive(false);
            hp2.SetActive(false);
            hp1.SetActive(false);
        }

        if (other.CompareTag("Skeleton"))
        {
            if(!playerhealth.isInvincible)
            {
                hp1.SetActive(false);
                hp2.SetActive(false);
                hp3.SetActive(false);

            }
        }

        if (other.CompareTag("Fire"))
        {
            hp1.SetActive(false);
            hp2.SetActive(false);
            hp3.SetActive(false);
        }
        if(other.CompareTag("Trap"))
        {
            if(!playerhealth.isInvincible)
            {
                if (hp3.activeSelf == true)
                {
                    hp3.SetActive(false);
                }
                else if (hp2.activeSelf == true)
                {
                    hp2.SetActive(false);
                }
                else if (hp1.activeSelf == true)
                {
                    hp1.SetActive(false);
                }
            }
        }
    }
}
