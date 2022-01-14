using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    ItemContext tempContext;

    public class ItemData
    {
        public ItemSO itemSO;
        public int num;
        public ItemData(ItemSO itemSO, int num)
        {
            this.itemSO = itemSO;
            this.num = num;
        }
    }
    [SerializeField]
    List<ItemData> items = new List<ItemData>();

    int index = 0;

    public bool IsEmpty { get { return items.Count == 0; } }
    
    public void Add(ItemSO item)
    {
        for(int i = items.Count - 1; i >= 0; --i)
        {
            if (item == items[i].itemSO)
            {
                items[i].num += 1;
                UpdateSlot(index);
                return;
            }
        }

        if (items.Count >= 12) // ¼ÒÁöÇ°ÀÌ ²ËÃ¡½À´Ï´Ù.
            return;
        items.Add(new ItemData(item, 1));
        UpdateSlot(index);
    }

    public void ChangeSlot(bool Right)
    {
        if (Right) ++index;
        else --index;

        index = Mathf.Clamp(index, 0, items.Count - 1);
        UpdateSlot(index);
    }

    public void UseCurrentSlot(Status status)
    {
        if (IsEmpty) return;

        items[index].itemSO.Use(status);
        if (--items[index].num == 0)
        {
            items.Remove(items[index]);
            ChangeSlot(false);
        }
        else
            UpdateSlot(index);
    }

    void UpdateSlot(int i)
    {

        if (i > 0)
            GameManager.Instance.HUDContext.ItemSlotL.Copy(items[i - 1].itemSO, items[i - 1].num);
        else
            GameManager.Instance.HUDContext.ItemSlotL.Copy(null);
        if (i < items.Count - 1)
            GameManager.Instance.HUDContext.ItemSlotR.Copy(items[i + 1].itemSO, items[i + 1].num);
        else
            GameManager.Instance.HUDContext.ItemSlotR.Copy(null);

        if (items.Count > 0)
            GameManager.Instance.HUDContext.ItemSlotC.Copy(items[i].itemSO, items[i].num);
        else
            GameManager.Instance.HUDContext.ItemSlotC.Copy(null);
    }
}
