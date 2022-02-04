using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    static BGMController _instance;

    void Awake()
    {
        if (_instance != null)
            Destroy(_instance.gameObject);
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
