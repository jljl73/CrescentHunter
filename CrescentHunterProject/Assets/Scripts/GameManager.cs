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
        {
            Debug.Log("GameManager is duplicated");
            Destroy(gameObject);
            return;
        }

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
    public UI_Effects UI;
    public UI_SFX SFX;

    public Vector3 StartPoint { get; set; }

    public void ChangeScene(int index)
    {
        NextSceneIndex = index;
        SceneManager.LoadScene(3);
    }

    public void ModeChange(Mode mode)
    {
        gameMode = mode;
    }

    public void Restart()
    {
        StartCoroutine(Resurrection(2.0f, 5.0f));
    }

    public void QuestClear()
    {
        UI.ShowClearPanel();
    }


    IEnumerator Resurrection(float Duration, float Delay)
    {
        UI.FadeOut(Duration);
        yield return new WaitForSeconds(Delay);
        player.transform.position = StartPoint;
        UI.FadeIn(Duration);
        player.Resurrection();
    }
}
