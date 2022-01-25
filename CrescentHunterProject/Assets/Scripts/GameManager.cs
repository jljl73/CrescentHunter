using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using M4u;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    static public GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject newGameObject = new GameObject();
                _instance = newGameObject.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance)
        { Debug.Log("GameManager is duplicated"); return; }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    

    public enum Mode { Play, UI }
    public int NextSceneIndex;

    Mode gameMode;
    public Mode GameMode => gameMode;
    public VM_HUD HUDContext;
    public VM_BlackSmith BlackSmithContext;
    public VM_Inventory InventoryContext;
    public Player player;
    public LogManager logManager;

    [SerializeField]
    GameObject QuestClearPanel;
    [SerializeField]
    Image EmtpyPanel;

    public void ChangeScene(int index)
    {
        NextSceneIndex = index;
        SceneManager.LoadScene(2);
    }

    public void ModeChange(Mode mode)
    {
        gameMode = mode;
    }

    public void Restart()
    {
        StartCoroutine(Resurrection(EmtpyPanel, 2.0f, 5.0f));
    }

    public void QuestClear()
    {
        QuestClearPanel.SetActive(true);
        StartCoroutine(Deactivate(QuestClearPanel, 30.0f));
    }

    IEnumerator Deactivate(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        ChangeScene(0);
    }


    IEnumerator Resurrection(Image image, float Duration, float Delay)
    {
        StartCoroutine(FadeOut(image, Duration));
        yield return new WaitForSeconds(Delay);
        player.transform.position = transform.position;
        StartCoroutine(FadeIn(image, Duration));
        player.Resurrection();
    }

    IEnumerator FadeOut(Image image, float Duration)
    {
        Color color = image.color;
        while (image.color.a < 1.0f)
        {
            image.color = new Color(color.r, color.g, color.b, image.color.a + Time.deltaTime / Duration);
            yield return null;
        }
    }

    IEnumerator FadeIn(Image image, float Duration)
    {
        Color color = image.color;
        while (image.color.a > 0.0f)
        {
            image.color = new Color(color.r, color.g, color.b, image.color.a - Time.deltaTime / Duration);
            yield return null;
        }
    }
}
