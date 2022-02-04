using UnityEngine;
using TMPro;

public class LogObject : MonoBehaviour
{
    TextMeshProUGUI content;

    void Start()
    {
        content = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Log(string value)
    {
        content.text = value;
    }
}
