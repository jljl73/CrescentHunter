using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    GameObject TitleCanvas;
    [SerializeField]
    GameObject CharacterCanvas;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            TitleCanvas.SetActive(false);
            CharacterCanvas.SetActive(true);
        }
            
    }

    public void OnChangeScene()
    {
        GameManager.Instance.ChangeScene(1);
    }
}
