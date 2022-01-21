using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using M4u;

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
        _instance = this;
    }

    public enum Mode { Play, UI }

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


    public void ModeChange(Mode mode)
    {
        gameMode = mode;
    }

    public void Restart()
    {
        StartCoroutine(FadeOut(EmtpyPanel, 2.0f, 3.0f));
    }

    public void QuestClear()
    {
        QuestClearPanel.SetActive(true);
        StartCoroutine(Deactivate(QuestClearPanel, 5.0f));
    }

    IEnumerator Deactivate(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    IEnumerator FadeOut(Image image, float Duration, float Delay)
    {
        Color color = image.color;
        while (image.color.a < 1.0f)
        {
            image.color = new Color(color.r, color.g, color.b, image.color.a + Time.deltaTime / Duration);
            yield return null;
        }
        yield return new WaitForSeconds(Delay);
        StartCoroutine(FadeIn(image, Duration));
    }

    IEnumerator FadeIn(Image image, float Duration)
    {
        player.transform.position = transform.position;
        player.Resurrection();
        Color color = image.color;
        while (image.color.a > 0.0f)
        {
            image.color = new Color(color.r, color.g, color.b, image.color.a - Time.deltaTime / Duration);
            yield return null;
        }
    }
}
