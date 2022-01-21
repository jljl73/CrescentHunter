using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M4u;

public class VM_Inventory : M4uContextMonoBehaviour
{
    M4uProperty<List<ItemContext>> items = new M4uProperty<List<ItemContext>>(new List<ItemContext>());
    List<ItemContext> Items { get => items.Value; set => items.Value = value; }

    M4uProperty<int> gold = new M4uProperty<int>();
    public int Gold { get => gold.Value; set => gold.Value = value; }

    private void Awake()
    {
        GameManager.Instance.InventoryContext = this;
    }

    public void Acquire(ItemSO itemSO, int num)
    {
        for(int i = 0; i < Items.Count;++i)
        {
            if(Items[i].Name == itemSO.ItemName)
            {
                Items[i].Num += num;
                return;
            }
        }
        Items.Add(new ItemContext(itemSO));
    }

    public void Remove(ItemSO itemSO, int num)
    {
        for (int i = 0; i < Items.Count; ++i)
        {
            if (Items[i].Name == itemSO.ItemName)
            {
                Items[i].Num -= num;
                if (Items[i].Num == 0)
                    Items.RemoveAt(i);
                return;
            }
        }
    }
}
