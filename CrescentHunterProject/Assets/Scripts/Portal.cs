using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    int NextSceneIndex = 0;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.position = transform.position + 4.0f * Vector3.forward;
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

}
