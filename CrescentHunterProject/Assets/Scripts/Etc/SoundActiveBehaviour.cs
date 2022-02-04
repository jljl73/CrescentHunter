using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActiveBehaviour : MonoBehaviour
{
    AudioSource audioSource;
    void Awake()
    {
        if (TryGetComponent<AudioSource>(out audioSource))
            audioSource = gameObject.AddComponent<AudioSource>();
        else
            Debug.Log("오디오 소스가 없습니다.");
    }

    void OnEnable()
    {
        audioSource.Play();
    }

}

