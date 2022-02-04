using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    Inventory inventory;
    Player player;

    [SerializeField]
    DataSO data;
    [SerializeField]
    ItemDB itemDB;

    void Start()
    {
        GameManager.Instance.StartPoint = transform.position;

        data.Load();
        player = GameManager.Instance.player;
        inventory = Inventory.Instance;
        inventory.SetGold(data.Gold);

        LoadEquipment();
        LoadItem();

        player.OnEquip(data.Index);
    }

    private void OnDisable()
    {
        data.Save(player);
        data.Save(inventory, itemDB);
        data.Save(player.Equipment);
        data.Save();
    }

    void LoadItem()
    {
        foreach(var t in data.Items)
        {
            inventory.Set(itemDB.GetItem(t.index), t.value);
        }
    }

    void LoadEquipment()
    {
        for (int i = 0; i < data.HasWeapons.Count; ++i)
        {
            if (data.HasWeapons[i])
                player.Equipment.AcquireWeapon(i);
        }
    }

}