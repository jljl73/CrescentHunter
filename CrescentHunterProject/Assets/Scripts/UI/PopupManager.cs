using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    static PopupManager _instance = null;
    static public PopupManager Instance
    { get => _instance; }

    public enum Type { BlackSmith, Market, Inventory, Entrance, Quest, Equipment };
    
    //
    [SerializeField]
    GameObject[] Popups;

    [SerializeField]
    Type currentPopup;
    Stack<GameObject> OpenedPopups = new Stack<GameObject>();


    bool cursorInScreen = true;

    private void Awake()
    {
        if (_instance) Debug.Log("PopupManager is duplicated");
        _instance = this;
        //CursorLock(true);
    }

    public void ShowPopup(Type type)
    {
        Popups[(int)type].SetActive(true);
        Popups[(int)type].transform.SetAsLastSibling();
        OpenedPopups.Push(Popups[(int)type]);
        GameManager.Instance.SFX.Play(0);
        CursorLock(false);
    }

    public void HidePopup(Type type)
    {
        if (OpenedPopups.Count == 0) return;

        GameManager.Instance.SFX.Play(0);
        OpenedPopups.Pop().SetActive(false);
        if (OpenedPopups.Count == 0);
            CursorLock(true);
    }

    void Update()
    {
        // 마우스 잠금
        if (Input.GetKeyDown(KeyCode.LeftControl))
            CursorLock(!cursorInScreen);

        // 팝업창 종료
        if (Input.GetKeyDown(KeyCode.Escape))
            HidePopup(currentPopup);

        if (Input.GetKeyDown(KeyCode.Tab))
            ShowPopup(Type.Inventory);
        if (Input.GetKeyUp(KeyCode.Tab))
            HidePopup(Type.Inventory);
    }

    public void CursorLock(bool value)
    {
        cursorInScreen = value;
        Cursor.lockState = cursorInScreen ? CursorLockMode.Locked : CursorLockMode.None;

        if(cursorInScreen)
            GameManager.Instance.ModeChange(GameManager.Mode.Play);
        else
            GameManager.Instance.ModeChange(GameManager.Mode.UI);
    }
}
