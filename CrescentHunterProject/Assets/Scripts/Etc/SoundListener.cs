using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundListener : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;
    AudioSource audioSource;

    void Start()
    {
        if(!TryGetComponent<AudioSource>(out audioSource))
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnSound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}
