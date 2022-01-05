using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M4u;

public class ItemContext : M4uContext
{
    M4uProperty<string> name = new M4uProperty<string>("");
    M4uProperty<Sprite> sprite = new M4uProperty<Sprite>();
    M4uProperty<int> num = new M4uProperty<int>();

    public string Name { get { return name.Value; } set { name.Value = value; } }
    public Sprite Sprite { get { return sprite.Value; } set { sprite.Value = value; } }
    public int Num { get { return num.Value; } set { num.Value = value; } }

    public ItemContext()
    {
        Name = "¾øÀ½";
        Num = 0;
        Sprite = null;
    }

    public ItemContext(string name, Sprite sprite, int num)
    {
        Name = name;
        Sprite = sprite;
        Num = num;
    }

    public ItemContext(ItemContext itemContext)
    {
        Name = itemContext.Name;
        Sprite = itemContext.Sprite;
        Num = itemContext.Num;
    }

    public void Copy(ItemContext itemContext)
    {
        Name = itemContext.Name;
        Sprite = itemContext.Sprite;
        Num = itemContext.Num;
    }

}
