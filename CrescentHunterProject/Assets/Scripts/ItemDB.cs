using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataBase", menuName = "ScriptableObjects/DataBase")]
public class ItemDB : ScriptableObject
{
    [Header("기타 아이템")]
    [SerializeField]
    ItemSO[] items;

    public int GetIndex(ItemSO item)
    {
        for (int i = 0; i < items.Length; ++i)
            if (item == items[i])
                return i;

        return -1;
    }

    public ItemSO GetItem(int index)
    {
        if (index < 0 || index >= items.Length)
        {
            Debug.Log("Index is wrong");
            return null;
        }
        return items[index];
    }
}
