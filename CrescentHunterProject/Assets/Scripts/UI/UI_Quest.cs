using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Quest : MonoBehaviour
{

    int index = -1;

    private void OnEnable()
    {
        index = -1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            EnterDungeon();
    }

    public void SelectQuest(int index)
    {
        this.index = index;
    }

    public void EnterDungeon()
    {
        if(index != -1)
            GameManager.Instance.ChangeScene(index);
    }

}
