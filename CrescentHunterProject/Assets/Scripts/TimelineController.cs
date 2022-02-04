using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    static bool IsPlayed = false;

    void Awake()
    {
        if (IsPlayed) return;
        
        GetComponent<PlayableDirector>().Play();
        IsPlayed = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }
}
