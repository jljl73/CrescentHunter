using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    static SoundPlayer _instance = null;

    static public SoundPlayer Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null)
            Debug.Log("SoundPlayer exist more than one");
        _instance = this;
    }


    [SerializeField]
    AudioSource[] audioSources;

    public void Play(int index)
    {
        audioSources[index].time = 0.1f;
        audioSources[index].Play();
    }
}
