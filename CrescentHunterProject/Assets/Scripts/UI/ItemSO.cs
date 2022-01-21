using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    Sprite sprite;
    public Sprite Sprite { get => sprite; }
    [SerializeField]
    string itemName;
    public string ItemName { get => itemName; }
    [SerializeField]
    int num = 0;
    public int Num { get => num; set => num = value; }
    [SerializeField]
    int price = 0;
    public int Price { get => price; }


    public virtual void Use(Status status)
    {

    }
}