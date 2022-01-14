using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteraction
{
    [SerializeField]
    string iName;
    public string IName => iName;

    [SerializeField]
    GameObject Popup;

    public void OnInteraction()
    {
        Popup?.SetActive(true);
        GameManager.Instance.ModeChange(GameManager.Mode.UI);
    }
}