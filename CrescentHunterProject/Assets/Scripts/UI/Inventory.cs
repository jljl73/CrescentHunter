using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    ItemContext[] items = new ItemContext[12];
    
    public void Add(ItemSO item)
    {
        int emptyIndex = -1;
        for(int i = items.Length - 1; i >= 0; --i)
        {
            if (items[i] == null)
                emptyIndex = i;
            else if (item.ItemName == items[i].Name)
            {
                items[i].Num += item.Num;
                return;
            }
        }

        if (emptyIndex > -1)
            items[emptyIndex] = new ItemContext(item.ItemName, item.Sprite, item.Num);
        SlotChange(0);
    }

    public void Print()
    {
        for(int i = 0; i < items.Length;++i)
        {
            if (items[i] != null)
            {
                Debug.Log(i);
                Debug.Log(items[i].Name + items[i].Num.ToString());
            }
        }
    }

    public void SlotChange(int i)
    {
        GameManager.Instance.Context.ItemSlotC = items[0];
    }
}
