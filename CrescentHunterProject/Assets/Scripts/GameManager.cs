using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public enum Mode { Play, UI }

    Mode gameMode;
    public Mode GameMode => gameMode;
    public VM_HUD HUDContext;
    public VM_BlackSmith BlackSmithContext;
    public Player player;
    public LogManager logManager;

    public void ModeChange(Mode mode)
    {
        gameMode = mode;
    }
}
