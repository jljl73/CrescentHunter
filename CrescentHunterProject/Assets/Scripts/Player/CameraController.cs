using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 5.0f;
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    Transform playerTransform;

    float mouseX = 0.0f;
    float mouseY = 0.0f;
    float distance = 3.0f;

    void LateUpdate()
    {
        // 게임상태 확인
        if (GameManager.Instance.GameMode == GameManager.Mode.Play)
        {
            mouseX += Input.GetAxis("Mouse X") * sensitivity;
            mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
            distance -= Input.GetAxis("Mouse ScrollWheel");
            distance = Mathf.Clamp(distance, 1.0f, 3.0f);

            mouseY = Mathf.Clamp(mouseY, -10.0f, 60.0f);
            transform.localEulerAngles = new Vector3(mouseY, mouseX, 0);
        }

        transform.position = transform.localRotation * Vector3.back * distance + offset + playerTransform.position;
    }
}
