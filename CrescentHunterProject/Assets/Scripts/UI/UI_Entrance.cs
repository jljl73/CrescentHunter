using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Entrance : MonoBehaviour
{
    [SerializeField]
    int NextSceneIndex = 0;

    PopupManager popupManager;

    void Start()
    {
        popupManager = transform.parent.GetComponent<PopupManager>();
    }

    public void ChangeScene()
    {
        GameManager.Instance.ChangeScene(NextSceneIndex);
    }

    public void Exit()
    {
        popupManager.HidePopup(PopupManager.Type.Entrance);
    }
}
