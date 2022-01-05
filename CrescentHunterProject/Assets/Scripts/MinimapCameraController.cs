using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    [SerializeField]
    Vector3 offset = new Vector3(0, 11.0f, 0.0f);

    Transform player;

    void Start()
    {
        player = GameManager.Instance.player.transform;
    }

    void Update()
    {
        transform.position = player.position + offset;
    }
}
