using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    public int NextSceneIndex=0;
    [SerializeField]
    Transform LoadingCircleBar;
    [SerializeField]
    Image LoadingBar;
    [SerializeField]
    TextMeshProUGUI percent;

    void Start()
    {
        NextSceneIndex = GameManager.Instance.NextSceneIndex;
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asynload = SceneManager.LoadSceneAsync(NextSceneIndex);
        asynload.allowSceneActivation = false;
        float Timer = 0.0f;

        while (asynload.progress < 0.9f)
        {
            yield return null;

            LoadingCircleBar.Rotate(Vector3.forward, Time.deltaTime * -240.0f);
            Timer += Time.deltaTime;
            LoadingBar.fillAmount = Mathf.Clamp(Timer, 0, 0.9f);
            percent.text = string.Format("{0}", asynload.progress * 100.0f) + " %";

        }

        LoadingBar.fillAmount = 1.0f;
        yield return new WaitForSeconds(1.0f);
        asynload.allowSceneActivation = true;
    }
}
