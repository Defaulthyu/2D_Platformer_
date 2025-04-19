using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    private AudioSource audioSource1;
    private AudioSource audioSource0;
    public AudioClip buttonClick1;
    public AudioClip buttonClick0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        audioSource0 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayButtonClickOpen()
    {
        audioSource1.PlayOneShot(buttonClick1);
    }

    public void PlayButtonClickClose()
    {
        audioSource0.PlayOneShot(buttonClick0);
    }
}
