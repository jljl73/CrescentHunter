using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    void Awake()
    { 
        if (GameManager.Instance.logManager != null)
            Debug.Log("LogManager is Duplicate");
        GameManager.Instance.logManager = this;
    }


}
