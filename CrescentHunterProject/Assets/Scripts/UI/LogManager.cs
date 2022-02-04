using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogManager : MonoBehaviour
{
    [SerializeField]
    GameObject LogPrefab;
    [SerializeField]
    float Duration = 10.0f;

    GameObject newLog;
    Stack<GameObject> Logs = new Stack<GameObject>();
    WaitForSeconds wait;

    void Awake()
    {
        wait = new WaitForSeconds(Duration);

        if (GameManager.Instance.logManager != null)
            Debug.Log("LogManager is Duplicate");
        GameManager.Instance.logManager = this;
    }

    public void Log(string value)
    {
        if (Logs.Count == 0)
            Logs.Push(Instantiate(LogPrefab, transform));

        GameObject newLog = Logs.Pop();
        gameObject.SetActive(true);
        newLog.GetComponentInChildren<TextMeshProUGUI>().text = value;
        StartCoroutine(IPush(newLog));
    }
    IEnumerator IPush(GameObject gameObject)
    {
        yield return wait;
        gameObject.SetActive(false);
        Logs.Push(gameObject);
    }

}
