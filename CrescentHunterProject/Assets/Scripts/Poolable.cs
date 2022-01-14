using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    [SerializeField]
    string key = "";
    public string Key { get => key; }

    [SerializeField]
    bool isCanvas = false;
    public bool IsCanvas { get => isCanvas; }

    Stack<GameObject> pool;

    void Start()
    {
        pool = ObjectPool.Instance.pool[Key];
    }

    void OnDisable()
    {
        pool.Push(gameObject);
    }
}
