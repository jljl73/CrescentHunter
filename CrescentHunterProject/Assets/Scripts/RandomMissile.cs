using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomMissile : MonoBehaviour
{
    [SerializeField]
    float UpSpeed;
    [SerializeField]
    float DownSpeed;
    [SerializeField]
    float UpDuration;
    [SerializeField]
    float Duration = 2.0f;

    bool bGoUp;

    void OnEnable()
    {
        bGoUp = true;
        StartCoroutine(GoUp());
        Invoke("StopUp", UpDuration);
        Invoke("Disappear", Duration);
    }

    void StopUp()
    {
        bGoUp = false;
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }

    IEnumerator GoUp()
    {
        while (bGoUp == true)
        {
            transform.Translate(Vector3.up * UpSpeed * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(GoDown());
    }

    IEnumerator GoDown()
    {
        while (gameObject.activeSelf)
        {
            transform.Translate(Vector3.down * DownSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
