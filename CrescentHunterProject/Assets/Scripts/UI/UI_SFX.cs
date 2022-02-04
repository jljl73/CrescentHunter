using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SFX : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;
    AudioSource audioSource;
    
    void Awake()
    {
        GameManager.Instance.SFX = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void Play(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}
