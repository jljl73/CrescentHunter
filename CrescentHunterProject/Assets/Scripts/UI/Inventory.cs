using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    static Inventory _instance = null;
    public static Inventory Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Inventory();
            return _instance;
        }
    }

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
    public List<ItemData> Items { get => items; }

    int index = 0;
    int gold = 0;
    public bool IsEmpty { get { return items.Count == 0; } }

    public int Gold { get => gold; }

    public void AddGold(int value)
    {
        gold += value;
        GameManager.Instance.InventoryContext.Gold = gold;
    }

    public void SetGold(int value)
    {
        gold = value;
        GameManager.Instance.InventoryContext.Gold = gold;
    }

    public bool SubGold(int value)
    {
        if (value > gold)
        {
            Debug.Log("±›æ◊¿Ã ∏¿⁄∂¯¥œ¥Ÿ.");
            return false;
        }
        else
        {
            gold -= value;
            GameManager.Instance.InventoryContext.Gold = gold;
            return true;
        }
    }

    public void Acquire(ItemSO item)
    {
        for(int i = items.Count - 1; i >= 0; --i)
        {
            if (item == items[i].itemSO)
            {
                items[i].num += 1;
                UpdateSlot(index);
                GameManager.Instance.InventoryContext.Acquire(item, 1);
                GameManager.Instance.logManager.Log(item.ItemName + " »πµÊ");
                return;
            }
        }

        if (items.Count >= 12) // º“¡ˆ«∞¿Ã ≤À√°Ω¿¥œ¥Ÿ.
            return;

        GameManager.Instance.logManager.Log(item.ItemName + " »πµÊ");
        GameManager.Instance.InventoryContext.Acquire(item, 1);
        items.Add(new ItemData(item, 1));
        UpdateSlot(index);
    }


    public void Set(ItemSO item, int num)
    {
        for (int i = items.Count - 1; i >= 0; --i)
        {
            if (item == items[i].itemSO)
            {
                items[i].num = num;
                UpdateSlot(index);
                GameManager.Instance.InventoryContext.Set(item, num);
                return;
            }
        }
        GameManager.Instance.InventoryContext.Set(item, num);
        items.Add(new ItemData(item, num));
        UpdateSlot(index);
    }


    public void Remove(ItemSO item, int num)
    {
        for (int i = items.Count - 1; i >= 0; --i)
        {
            if (item == items[i].itemSO)
            {
                if(items[i].num >= num)
                items[i].num -= num;

                if (items[index].num == 0)
                {
                    items.Remove(items[index]);
                    ChangeSlot(false);
                }
                else
                    UpdateSlot(index);
                return;
            }
        }

        if (items.Count >= 12) // º“¡ˆ«∞¿Ã ≤À√°Ω¿¥œ¥Ÿ.
            return;

        GameManager.Instance.InventoryContext.Remove(item, num);
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
        if (!IsUsable()) return;

        items[index].itemSO.Use(status);
        if (--items[index].num == 0)
        {
            items.Remove(items[index]);
            ChangeSlot(false);
        }
        else
            UpdateSlot(index);
    }

    public bool IsUsable()
    {
        return items[index].itemSO.GetType() == typeof(ItemConsumable);
    }

    public int GetNumberItem(ItemSO itemSO)
    {
        for(int i = 0; i < items.Count; ++i)
        {
            if (items[i].itemSO == itemSO)
                return items[i].num;
        }
        return 0;
    }

    public void UpdateSlot()
    {
        UpdateSlot(index);
    }
    
    void UpdateSlot(int i)
    {
        if (i > 0)
            GameManager.Instance.HUDContext.ItemSlotL.Copy(items[i - 1].itemSO, items[i - 1].num, items[i - 1].itemSO.Num);
        else
            GameManager.Instance.HUDContext.ItemSlotL.Copy(null);

        if (i < items.Count - 1)
            GameManager.Instance.HUDContext.ItemSlotR.Copy(items[i + 1].itemSO, items[i + 1].num, items[i + 1].itemSO.Num);
        else
            GameManager.Instance.HUDContext.ItemSlotR.Copy(null);

        if (items.Count > 0)
            GameManager.Instance.HUDContext.ItemSlotC.Copy(items[i].itemSO, items[i].num, items[i].itemSO.Num);
        else
            GameManager.Instance.HUDContext.ItemSlotC.Copy(null);
    }
}
