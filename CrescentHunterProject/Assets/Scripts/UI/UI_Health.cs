using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour 
{
    Image image;
    public int Hp = 0;
    public int MaxHp = 100;

    void Start()
    {
        image = GetComponent<Image>();
        
    }



}
