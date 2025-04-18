using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonClick;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClick);
    }
}
