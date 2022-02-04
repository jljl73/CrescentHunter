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
            Debug.Log("����� �ҽ��� �����ϴ�.");
    }

    void OnEnable()
    {
        audioSource.Play();
    }

}

