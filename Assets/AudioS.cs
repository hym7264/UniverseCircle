using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioS : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Play_BGM()
    {
        audioSource.clip= audioClip;
        audioSource.Play();
    }
}
