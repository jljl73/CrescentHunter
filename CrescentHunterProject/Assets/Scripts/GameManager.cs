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

    public M4uContextMonoBehaviour Context;
    public Player player;
    public LogManager logManager;
}
