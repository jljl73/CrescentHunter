using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteraction
{
    [SerializeField]
    string iName;
    public string IName => iName;

    [SerializeField]
    PopupManager.Type[] Popups;

    public void OnInteraction()
    {
        for(int i = 0; i < Popups.Length;++i)
            PopupManager.Instance.ShowPopup(Popups[i]);
    }
}