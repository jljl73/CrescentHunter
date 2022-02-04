using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M4u;

public class ItemContext : M4uContext
{
    M4uProperty<string> name = new M4uProperty<string>("");
    M4uProperty<Sprite> sprite = new M4uProperty<Sprite>();
    M4uProperty<int> num = new M4uProperty<int>();
    M4uProperty<int> maxNum = new M4uProperty<int>();
    M4uProperty<int> price = new M4uProperty<int>();

    public string Name { get { return name.Value; } set { name.Value = value; } }
    public Sprite Sprite { get { return sprite.Value; } set { sprite.Value = value; } }
    public int Num { get { return num.Value; } set { num.Value = value; } }
    public int MaxNum { get { return maxNum.Value; } set { maxNum.Value = value; } }
    public int Price { get { return price.Value; } set { price.Value = value; } }

    public ItemContext()
    {
        Name = "없음";
        Num = 0;
        Sprite = null;
        MaxNum = 0;
        Price = 0;
    }

    public ItemContext(ItemSO itemSO, int num)
    {
        Name = itemSO.ItemName;
        Sprite = itemSO.Sprite;
        this.Num = num;
        MaxNum = itemSO.Num;
        Price = itemSO.Price;
    }

    public ItemContext(string name, Sprite sprite, int num, int maxNum)
    {
        Name = name;
        Sprite = sprite;
        Num = num;
        MaxNum = maxNum;
    }

    public ItemContext(ItemContext itemContext)
    {
        Name = itemContext.Name;
        Sprite = itemContext.Sprite;
        Num = itemContext.Num;
        MaxNum = itemContext.MaxNum;
    }

    public void Copy(ItemContext itemContext)
    {
        if (itemContext == null)
        {
            Name = "없음";
            Num = 0;
            MaxNum = 0;
            return;
        }

        Name = itemContext.Name;
        Sprite = itemContext.Sprite;
        Num = itemContext.Num;
        MaxNum = itemContext.MaxNum;
    }

    public void Copy(ItemSO itemSO, int Num, int MaxNum)
    {
        this.Name = itemSO.ItemName;
        this.Sprite = itemSO.Sprite;
        this.Num = Num;
        this.MaxNum = MaxNum;
    }

    public void Copy(string Name, Sprite Sprite, int Num, int MaxNum)
    {
        this.Name = Name;
        this.Sprite = Sprite;
        this.Num = Num;
        this.MaxNum = MaxNum;
    }

}
