using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip deadClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(deadClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
