using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_QuestClear : MonoBehaviour
{
    [SerializeField]
    float Duration = 30.0f;
    [SerializeField]
    TextMeshProUGUI timer;

    float RemainTime = 0.0f;


    void OnEnable()
    {
        StartCoroutine(ChangeSceneDuration(Duration));
        RemainTime = Duration;
    }

    void Update()
    {
        RemainTime -= Time.deltaTime;
        timer.text = string.Format("{0:0#}", RemainTime);
    }

    IEnumerator ChangeSceneDuration(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.ChangeScene(1);
    }
}
