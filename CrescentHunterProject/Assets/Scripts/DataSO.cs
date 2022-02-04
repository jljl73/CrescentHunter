using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class DataForm
{
    public int gold = 0;
    public int index = 0;
    public List<DataSO.ListElement> items = new List<DataSO.ListElement>();
    public List<bool> hasWeapons = new List<bool>();

    public static DataForm CreateFromJson(string Jsonstring)
    {
        return JsonUtility.FromJson<DataForm>(Jsonstring);
    }
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data")]
public class DataSO : ScriptableObject
{
    [System.Serializable]
    public struct ListElement
    {
        public int index;
        public int value;
        public ListElement(int index, int value)
        {
            this.index = index;
            this.value = value;
        }
    }
    
    [Header("보유 골드")]
    [SerializeField]
    int gold = 0;
    public int Gold { get => gold; }

    [Header("장착 무기")]
    [SerializeField]
    int index = 0;
    public int Index { get => index; }
    [SerializeField]
    List<bool> hasWeapons = new List<bool>();
    public List<bool> HasWeapons { get => hasWeapons; }

    [Header("인벤토리")]
    [SerializeField]
    List<ListElement> items = new List<ListElement>();
    public List<ListElement> Items { get => items; }



    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

    public void Save()
    {
        if (!Directory.Exists(Application.dataPath + "/Saves"))
            Directory.CreateDirectory(Application.dataPath + "/Saves");

        File.WriteAllText(Application.dataPath + "/Saves/Data.json", SaveToString());
    }

    public void Save(Player player)
    {
        this.index = player.Equipment.CurWeaponIndex;
    }

    public void Save(Inventory inventory, ItemDB itemDB)
    {
        items.Clear();
        foreach(var Item in inventory.Items)
        {
            items.Add(new ListElement(itemDB.GetIndex(Item.itemSO), Item.num));
        }
        gold = inventory.Gold;
    }

    public void Save(Equipment equipment)
    {
        hasWeapons.Clear();
        hasWeapons.AddRange(equipment.HasWeapons);
    }

    public void Load()
    {
        if (!File.Exists(Application.dataPath + "/Saves/Data.json"))
            return;

        string Json = File.ReadAllText(Application.dataPath + "/Saves/Data.json");
        Copy(DataForm.CreateFromJson(Json));
    }

    public void Copy(DataForm other)
    {
        this.gold = other.gold;
        this.index = other.index;
        this.hasWeapons = other.hasWeapons;
        this.items = other.items;
    }
}